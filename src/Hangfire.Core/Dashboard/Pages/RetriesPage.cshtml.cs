#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hangfire.Dashboard.Pages
{
    
    #line 2 "..\..\Dashboard\Pages\RetriesPage.cshtml"
    using System;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Dashboard\Pages\RetriesPage.cshtml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    using System.Linq;
    using System.Text;
    
    #line 4 "..\..\Dashboard\Pages\RetriesPage.cshtml"
    using Hangfire;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Dashboard\Pages\RetriesPage.cshtml"
    using Hangfire.Common;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Dashboard\Pages\RetriesPage.cshtml"
    using Hangfire.Dashboard;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Dashboard\Pages\RetriesPage.cshtml"
    using Hangfire.Dashboard.Pages;
    
    #line default
    #line hidden
    
    #line 8 "..\..\Dashboard\Pages\RetriesPage.cshtml"
    using Hangfire.Dashboard.Resources;
    
    #line default
    #line hidden
    
    #line 9 "..\..\Dashboard\Pages\RetriesPage.cshtml"
    using Hangfire.Storage;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class RetriesPage : RazorPage
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");











            
            #line 11 "..\..\Dashboard\Pages\RetriesPage.cshtml"
  
    Layout = new LayoutPage(Strings.RetriesPage_Title);
    
    int from, perPage;

    int.TryParse(Query("from"), out from);
    int.TryParse(Query("count"), out perPage);

    Pager pager = null;
    List<string> jobIds = null;

    using (var connection = Storage.GetConnection())
    {
        var storageConnection = connection as JobStorageConnection;

        if (storageConnection != null)
        {
            pager = new Pager(@from, perPage, storageConnection.GetSetCount("retries"));
            jobIds = storageConnection.GetRangeFromSet("retries", pager.FromRecord, pager.FromRecord + pager.RecordsPerPage - 1);
        }
    }


            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 34 "..\..\Dashboard\Pages\RetriesPage.cshtml"
 if (pager == null)
{

            
            #line default
            #line hidden
WriteLiteral("    <div class=\"alert alert-warning\">\r\n        ");


            
            #line 37 "..\..\Dashboard\Pages\RetriesPage.cshtml"
   Write(Html.Raw(String.Format(Strings.RetriesPage_Warning_Html, Url.To("/jobs/scheduled"))));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n");


            
            #line 39 "..\..\Dashboard\Pages\RetriesPage.cshtml"
}
else
{

            
            #line default
            #line hidden
WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <h1 class=\"pa" +
"ge-header\">");


            
            #line 44 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                               Write(Strings.RetriesPage_Title);

            
            #line default
            #line hidden
WriteLiteral("</h1>\r\n");


            
            #line 45 "..\..\Dashboard\Pages\RetriesPage.cshtml"
             if (jobIds.Count == 0)
            {

            
            #line default
            #line hidden
WriteLiteral("                <div class=\"alert alert-success\">\r\n                    ");


            
            #line 48 "..\..\Dashboard\Pages\RetriesPage.cshtml"
               Write(Strings.RetriesPage_NoJobs);

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n");


            
            #line 50 "..\..\Dashboard\Pages\RetriesPage.cshtml"
            }
            else
            {

            
            #line default
            #line hidden
WriteLiteral("                <div class=\"js-jobs-list\">\r\n                    <div class=\"btn-t" +
"oolbar btn-toolbar-top\">\r\n");


            
            #line 55 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                         if (!IsReadOnly)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <button class=\"js-jobs-list-command btn btn-sm btn-pr" +
"imary\"\r\n                                    data-url=\"");


            
            #line 58 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                         Write(Url.To("/jobs/scheduled/enqueue"));

            
            #line default
            #line hidden
WriteLiteral("\"\r\n                                    data-loading-text=\"");


            
            #line 59 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                                  Write(Strings.Common_Enqueueing);

            
            #line default
            #line hidden
WriteLiteral("\"\r\n                                    disabled=\"disabled\">\r\n                    " +
"            <span class=\"glyphicon glyphicon-repeat\"></span>\r\n                  " +
"              ");


            
            #line 62 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                           Write(Strings.Common_EnqueueButton_Text);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </button>\r\n");


            
            #line 64 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                        }

            
            #line default
            #line hidden

            
            #line 65 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                         if (!IsReadOnly)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <button class=\"js-jobs-list-command btn btn-sm btn-de" +
"fault\"\r\n                                    data-url=\"");


            
            #line 68 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                         Write(Url.To("/jobs/scheduled/delete"));

            
            #line default
            #line hidden
WriteLiteral("\"\r\n                                    data-loading-text=\"");


            
            #line 69 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                                  Write(Strings.Common_Deleting);

            
            #line default
            #line hidden
WriteLiteral("\"\r\n                                    data-confirm=\"");


            
            #line 70 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                             Write(Strings.Common_DeleteConfirm);

            
            #line default
            #line hidden
WriteLiteral("\"\r\n                                    disabled=\"disabled\">\r\n                    " +
"            <span class=\"glyphicon glyphicon-remove\"></span>\r\n                  " +
"              ");


            
            #line 73 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                           Write(Strings.Common_DeleteSelected);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </button>\r\n");


            
            #line 75 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                        ");


            
            #line 76 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                   Write(Html.PerPageSelector(pager));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n\r\n                    <div class=\"table-responsive\"" +
">\r\n                        <table class=\"table table-hover\">\r\n                  " +
"          <thead>\r\n                                <tr>\r\n");


            
            #line 83 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                     if (!IsReadOnly)
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                        <th class=\"min-width\">\r\n                 " +
"                           <input type=\"checkbox\" class=\"js-jobs-list-select-all" +
"\"/>\r\n                                        </th>\r\n");


            
            #line 88 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                    }

            
            #line default
            #line hidden
WriteLiteral("                                    <th class=\"min-width\">");


            
            #line 89 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                                     Write(Strings.Common_Id);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                                    <th class=\"min-width\">");


            
            #line 90 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                                     Write(Strings.Common_State);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                                    <th>");


            
            #line 91 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                   Write(Strings.Common_Job);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                                    <th>");


            
            #line 92 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                   Write(Strings.Common_Reason);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                                    <th class=\"align-right\">");


            
            #line 93 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                                       Write(Strings.Common_Retry);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                                    <th class=\"align-right\">");


            
            #line 94 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                                       Write(Strings.Common_Created);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                                </tr>\r\n                            </thead" +
">\r\n                            <tbody>\r\n");


            
            #line 98 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                 foreach (var jobId in jobIds)
                                {
                                    JobData jobData;
                                    StateData stateData;

                                    using (var connection = Storage.GetConnection())
                                    {
                                        jobData = connection.GetJobData(jobId);
                                        stateData = connection.GetStateData(jobId);
                                    }


            
            #line default
            #line hidden
WriteLiteral("                                    <tr class=\"js-jobs-list-row ");


            
            #line 109 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                                            Write(jobData != null ? "hover" : null);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n");


            
            #line 110 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                         if (!IsReadOnly)
                                        {

            
            #line default
            #line hidden
WriteLiteral("                                            <td>\r\n                               " +
"                 <input type=\"checkbox\" class=\"js-jobs-list-checkbox\" name=\"jobs" +
"[]\" value=\"");


            
            #line 113 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                                                                                                     Write(jobId);

            
            #line default
            #line hidden
WriteLiteral("\"/>\r\n                                            </td>\r\n");


            
            #line 115 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                        }

            
            #line default
            #line hidden
WriteLiteral("                                        <td class=\"min-width\">\r\n                 " +
"                           ");


            
            #line 117 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                       Write(Html.JobIdLink(jobId));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                        </td>\r\n");


            
            #line 119 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                         if (jobData == null)
                                        {

            
            #line default
            #line hidden
WriteLiteral("                                            <td colspan=\"5\"><em>Job expired.</em>" +
"</td>\r\n");


            
            #line 122 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                        }
                                        else
                                        {

            
            #line default
            #line hidden
WriteLiteral("                                            <td class=\"min-width\">\r\n             " +
"                                   ");


            
            #line 126 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                           Write(Html.StateLabel(jobData.State));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </td>\r\n");



WriteLiteral("                                            <td class=\"word-break\">\r\n            " +
"                                    ");


            
            #line 129 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                           Write(Html.JobNameLink(jobId, jobData.Job));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </td>\r\n");



WriteLiteral("                                            <td>\r\n                               " +
"                 ");


            
            #line 132 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                            Write(stateData?.Reason);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </td>\r\n");



WriteLiteral("                                            <td class=\"align-right\">\r\n");


            
            #line 135 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                                 if (stateData != null && stateData.Data.ContainsKey("EnqueueAt"))
                                                {
                                                    
            
            #line default
            #line hidden
            
            #line 137 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                               Write(Html.RelativeTime(JobHelper.DeserializeDateTime(stateData.Data["EnqueueAt"])));

            
            #line default
            #line hidden
            
            #line 137 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                                                                                                                  
                                                }

            
            #line default
            #line hidden
WriteLiteral("                                            </td>\r\n");



WriteLiteral("                                            <td class=\"align-right\">\r\n           " +
"                                     ");


            
            #line 141 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                           Write(Html.RelativeTime(jobData.CreatedAt));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </td>\r\n");


            
            #line 143 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                        }

            
            #line default
            #line hidden
WriteLiteral("                                    </tr>\r\n");


            
            #line 145 "..\..\Dashboard\Pages\RetriesPage.cshtml"
                                }

            
            #line default
            #line hidden
WriteLiteral("                            </tbody>\r\n                        </table>\r\n         " +
"           </div>\r\n\r\n                    ");


            
            #line 150 "..\..\Dashboard\Pages\RetriesPage.cshtml"
               Write(Html.Paginator(pager));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n");


            
            #line 152 "..\..\Dashboard\Pages\RetriesPage.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </div>\r\n    </div>\r\n");


            
            #line 155 "..\..\Dashboard\Pages\RetriesPage.cshtml"
}
            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591