﻿// This file is part of Hangfire. Copyright © 2013-2014 Hangfire OÜ.
// 
// Hangfire is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as 
// published by the Free Software Foundation, either version 3 
// of the License, or any later version.
// 
// Hangfire is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public 
// License along with Hangfire. If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using Hangfire.Annotations;
using Hangfire.Common;
using Hangfire.Storage;
using Newtonsoft.Json;

namespace Hangfire.States
{
    /// <summary>
    /// Defines the <i>final</i> state of a background job when nobody
    /// is interested whether it was performed or not.
    /// </summary>
    /// <remarks>
    /// <para>Deleted state is used when you are not interested in a processing
    /// of a background job. This state isn't backed by any background process,
    /// so when you change a state of the job to the <i>Deleted</i>, only
    /// expiration time will be set on a job without any additional processing.</para>
    /// </remarks>
    /// 
    /// <example>
    /// <para>The following example demonstrates how to cancel an <i>enqueued</i> background
    /// job. Please note that this job may be processed before you change its state.</para>
    /// <para>This example shows how to create an instance of the <see cref="DeletedState"/>
    /// class and use the <see cref="IBackgroundJobClient.ChangeState"/> method. Please see
    /// <see cref="O:Hangfire.BackgroundJob.Delete">BackgroundJob.Delete</see>
    /// and <see cref="O:Hangfire.BackgroundJobClientExtensions.Delete">BackgroundJobClientExtensions.Delete</see>
    /// method overloads for simpler API.</para> 
    /// 
    /// <code lang="cs" source="..\Samples\States.cs" region="DeletedState" />
    /// 
    /// </example>
    /// 
    /// <seealso cref="O:Hangfire.BackgroundJob.Delete">BackgroundJob.Delete Overload</seealso>
    /// <seealso cref="O:Hangfire.BackgroundJobClientExtensions.Delete">BackgroundJobClientExtensions.Delete Overload</seealso>
    /// <seealso cref="IBackgroundJobClient.ChangeState" />
    /// 
    /// <threadsafety static="true" instance="false" />
    public class DeletedState : IState
    {
        public static readonly Exception DefaultException = new OperationCanceledException();

        /// <summary>
        /// Represents the name of the <i>Deleted</i> state. This is constant value.
        /// </summary>
        /// <remarks>
        /// The value of this field is <c>"Deleted"</c>.
        /// </remarks>
        public const string StateName = "Deleted";

        /// <summary>
        /// Initializes a new instance of the <see cref="DeletedState"/> class.
        /// </summary>
        public DeletedState() : this(null)
        {
        }

        public DeletedState([CanBeNull] ExceptionInfo exceptionInfo)
        {
            ExceptionInfo = exceptionInfo;
            DeletedAt = DateTime.UtcNow;
        }

        [JsonProperty("Ex", NullValueHandling = NullValueHandling.Ignore)]
        public ExceptionInfo ExceptionInfo { get; }

        /// <inheritdoc />
        /// <remarks>
        /// Always equals to <see cref="StateName"/> for the <see cref="DeletedState"/>.
        /// Please see the remarks section of the <see cref="IState.Name">IState.Name</see>
        /// article for the details.
        /// </remarks>
        [JsonIgnore]
        public string Name => StateName;

        /// <inheritdoc />
        public string Reason { get; set; }

        /// <inheritdoc />
        /// <remarks>
        /// Always returns <see langword="true"/> for the <see cref="DeletedState"/>.
        /// Please refer to the <see cref="IState.IsFinal">IState.IsFinal</see> documentation
        /// for the details.
        /// </remarks>
        [JsonIgnore]
        public bool IsFinal => true;

        /// <inheritdoc />
        /// <remarks>
        /// Always returns <see langword="true" /> for the <see cref="DeletedState"/>.
        /// Please see the description of this property in the
        /// <see cref="IState.IgnoreJobLoadException">IState.IgnoreJobLoadException</see>
        /// article.
        /// </remarks>
        [JsonIgnore]
        public bool IgnoreJobLoadException => true;

        /// <summary>
        /// Gets a date/time when the current state instance was created.
        /// </summary>
        [JsonIgnore]
        public DateTime DeletedAt { get; }

        /// <inheritdoc />
        /// <remarks>
        /// <para>Returning dictionary contains the following keys. You can obtain 
        /// the state data by using the <see cref="IStorageConnection.GetStateData"/>
        /// method.</para>
        /// <list type="table">
        ///     <listheader>
        ///         <term>Key</term>
        ///         <term>Type</term>
        ///         <term>Deserialize Method</term>
        ///         <description>Notes</description>
        ///     </listheader>
        ///     <item>
        ///         <term><c>DeletedAt</c></term>
        ///         <term><see cref="DateTime"/></term>
        ///         <term><see cref="JobHelper.DeserializeDateTime"/></term>
        ///         <description>Please see the <see cref="DeletedAt"/> property.</description>
        ///     </item>
        ///     <item>
        ///         <term><c>Exception</c></term>
        ///         <term><see cref="ExceptionInfo"/></term>
        ///         <term><see cref="SerializationHelper.Deserialize{T}(string, SerializationOption)"/> with <see cref="SerializationOption.Internal"/> option.</term>
        ///         <description>Can be absent or null. Please see the <see cref="Exception"/> property.</description>
        ///     </item>
        /// </list>
        /// </remarks>
        public Dictionary<string, string> SerializeData()
        {
            var result = new Dictionary<string, string>
            {
                { "DeletedAt", JobHelper.SerializeDateTime(DeletedAt) },
            };

            if (ExceptionInfo != null)
            {
                result.Add("Exception", SerializationHelper.Serialize(ExceptionInfo, SerializationOption.User));
            }

            return result;
        }

        internal sealed class Handler : IStateHandler
        {
            public void Apply(ApplyStateContext context, IWriteOnlyTransaction transaction)
            {
                transaction.IncrementCounter("stats:deleted");
            }

            public void Unapply(ApplyStateContext context, IWriteOnlyTransaction transaction)
            {
                transaction.DecrementCounter("stats:deleted");
            }

            // ReSharper disable once MemberHidesStaticFromOuterClass
            public string StateName => DeletedState.StateName;
        }
    }
}
