﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using Syncfusion.Report.Server.API.Helper.V3;
using Syncfusion.Report.Server.API.Helper.V2;
using Syncfusion.Report.Server.Api.Helper.V1;
using Syncfusion.Report.Server.Api.Helper.V3.Models;
using Syncfusion.Report.Server.Api.Helper.V2.Models;
using Syncfusion.Report.Server.Api.Helper.V1.Models;
using Syncfusion.Report.Server.API.Helper;
using System;

namespace Syncfusion.Report.Server.API.Sample
{
    internal class Program
    {
        //The test user credentials are given here and can access limited API's. Inorder to access all the API'S, admin credentials has to be used.

        private static string SyncfusionReportServerUrl = "https://reportserver.syncfusion.com/";//provide the syncfusion report server hosted URL
        private static string userName = "guest";// user credentials
        private static string password = "demo";

        public static void Main(string[] args)
        {
            #region Token generation

            var token = new ServerApiHelper().Connect(SyncfusionReportServerUrl, userName, password);

            #endregion

            #region Connect to version 1

            var v1ApiObject = new ServerClientV1();
            v1ApiObject.Connect(SyncfusionReportServerUrl, userName, password);

            #endregion

            #region Connect to version 2

            var v2ApiObject = new ServerClientV2();
            v2ApiObject.Connect(SyncfusionReportServerUrl, userName, password);

            #endregion

            #region Connect to version 3

            var v3ApiObject = new ServerClientV3();
            v3ApiObject.Connect(SyncfusionReportServerUrl, userName, password);

            #endregion

            #region V1

            #region V1 USERS

            #region Add user

            var addUserWithoutPassword = v1ApiObject.UsersEndPoint().CreateUser(new User()
            {
                Username = "sample",
                FirstName = "uuser",
                Lastname = "",
                Email = "sampleuser@syncfusion.com"
            });

            #endregion

            #region Get user list

            var userList = v1ApiObject.UsersEndPoint().GetAllUsers();

            #endregion

            #region variable declaration for users

            var userId = userList.UserList.Select(x => x.UserId).FirstOrDefault(); // Assign first userid in the user's list

            // Declare username or email id of the user from the user list

            var name = userList.UserList.Select(x => x.Username).FirstOrDefault(); // Assign first username in the user's list
            var emailId = userList.UserList.Select(x => x.Email).FirstOrDefault(); //Assign first email id in the user's list

            #endregion

            #region Update user

            // Update using username

            var updateUser = v1ApiObject.UsersEndPoint().UpdateUser(name, new User() { FirstName = "user" });

            // Update using email id

            // var updateUser = version1ApiObject.UsersEndPoint().UpdateUser(emailId, new User() { FirstName = "user" });

            #endregion

            #region Delete user

            var deleteUser = v1ApiObject.UsersEndPoint().DeleteUser(name);

            #endregion

            #region Get user detail

            var userDetail = v1ApiObject.UsersEndPoint().GetUser(name);

            #endregion

            #endregion

            #region V1 GROUPS

            #region Add group

            var addGroup = v1ApiObject.GroupsEndPoint().CreateGroup(new Group()
            {
                Name = "Test group",
                Description = "Testing"
            });

            #endregion

            #region Get group list

            var listGroup = v1ApiObject.GroupsEndPoint().GetAllGroups();

            #endregion

            #region Variable declaration for groups

            // Declare group id. Assigns first group id in the group list

            var groupId = listGroup.GroupList.Select(x => x.Id).FirstOrDefault();

            #endregion

            #region Update group

            var updateGroup = v1ApiObject.GroupsEndPoint().UpdateGroup(groupId,
                new Group()
                {
                    Name = "Testing group",
                    Description = "test"
                });

            #endregion

            #region Delete group

            var deleteGroup = v1ApiObject.GroupsEndPoint().DeleteGroup(groupId);

            #endregion

            #region Get group detail

            var groupDetails = v1ApiObject.GroupsEndPoint().GetGroup(groupId);

            #endregion

            #region Get members of group

            var groupMembers = v1ApiObject.GroupsEndPoint().GetGroupMembers(groupId);

            #endregion

            #endregion

            #endregion

            #region V2

            #region V2 ITEMS

            #region Get items

            //Get report list

            var reportItems = v2ApiObject.ItemsEndPoint().GetItems(ItemType.Report);

            //Get category list

            var categoryItems = v2ApiObject.ItemsEndPoint().GetItems(ItemType.Category);

            //Get datasource list

            var datasourceItems = v2ApiObject.ItemsEndPoint().GetItems(ItemType.Datasource);

            //Get dataset list

            var datasetItems = v2ApiObject.ItemsEndPoint().GetItems(ItemType.Dataset);

            //Get schedule list

            var scheduleItems = v2ApiObject.ItemsEndPoint().GetItems(ItemType.Schedule);

            //Get file list

            var fileItems = v2ApiObject.ItemsEndPoint().GetItems(ItemType.File);

            #endregion

            #endregion

            #region Variable declaration to get details of particular items

            var reportId = reportItems.Select(i => i.Id).FirstOrDefault(); //Assign the Id of first item in the report list
            var categoryId = categoryItems.Select(i => i.Id).FirstOrDefault(); //Assign the Id of first item in the category list
            var datasourceId = datasourceItems.Select(i => i.Id).FirstOrDefault(); //Assign the Id of first item in the datasource list
            var datasetId = datasetItems.Select(i => i.Id).FirstOrDefault(); //Assign the Id of first item in the dataset list
            var scheduleId = scheduleItems.Select(i => i.Id).FirstOrDefault(); //Assign the Id of first item in the schedule list
            var fileId = fileItems.Select(i => i.Id).FirstOrDefault(); //Assign the Id of first item in the file list

            #endregion

            #region Get item detail

            // Get details of particular report

            var reportDetails = v2ApiObject.ItemsEndPoint().GetItemDetail(reportId);

            // Get details of particular category

            var categoryDetails = v2ApiObject.ItemsEndPoint().GetItemDetail(categoryId);

            // Get details of particular datasource

            var datasourceDetails = v2ApiObject.ItemsEndPoint().GetItemDetail(datasourceId);

            // Get details of particular dataset

            var datasetDetals = v2ApiObject.ItemsEndPoint().GetItemDetail(datasetId);

            // Get details of particular schedule

            var scheduleDetails = v2ApiObject.ItemsEndPoint().GetItemDetail(scheduleId);

            // Get details of particular file

            var fileDetails = v2ApiObject.ItemsEndPoint().GetItemDetail(fileId);

            #endregion

            #region Get public reports

            var getPublicReports = v2ApiObject.ItemsEndPoint().GetPublicItems(ItemType.Report);

            #endregion          

            #region Get favorite report

            var favoriteReports = v2ApiObject.ItemsEndPoint().GetFavoriteItems();

            #endregion

            #region Add category

            var addCategory = v2ApiObject.ItemsEndPoint().AddCategory(new ApiCategoryAdd() { Name = "samplecategory" });

            #endregion

            #region Add report

            var addReport = v2ApiObject.ItemsEndPoint().AddReport(new ApiReportAdd()
            {
                Name = "Testing report",
                Description = "Testing purpose",
                CategoryId = categoryId,
                IsPublic = true, //Set ispublic Value to make and remove report Public Access
                ItemContent = File.ReadAllBytes("../../Sales Order Detail.rdl")
            });

            #endregion

            #region Add datasource

            var addDataSource = v2ApiObject.ItemsEndPoint().AddDataSource(new ApiReportDataSourceAdd()
            {
                Name = "Test datasource",
                Description = "Testing purpose",
                DataSourceDefinition = new DataSourceDefinition
                {
                    ConnectString = "Data Source=mvc.syncfusion.com;Initial Catalog=AdventureWorks;",
                    ServerType = ServerType.SQL,
                    CredentialRetrieval = CredentialRetrieval.Store,
                    UserName = "ssrs1",
                    Password = "RDLReport1"
                }
            });

            #endregion

            #region Add dataset

            var addDataset = v2ApiObject.ItemsEndPoint().AddDataset(new ApiReportDataSetAdd()
            {
                Name = "Test dataset",
                Description = "Testing purpose",
                DataSourceMappingInfo = new List<DataSourceMappingInfo> {
                    new DataSourceMappingInfo
                    {
                        DataSourceId = datasourceDetails.Id,
                        Name = datasourceDetails.Name
                    }
                },
                ItemContent = File.ReadAllBytes("../../Sales.rsd")
            });

            #endregion

            #region Add file

            var addWidget = v2ApiObject.ItemsEndPoint().AddFile(new ApiFileAdd()
            {
                Name = "Sample file",
                Description = "Testing purpose",
                ItemContent = File.ReadAllBytes("../../sample file.txt")
            });

            #endregion

            #region Check item name existence

            var checkNameExistence = v2ApiObject.ItemsEndPoint().IsItemNameExists(new ApiValidateItemName()
            {
                ItemName = "Sales Order Detail",
                ItemType = ItemType.Report.ToString(),
                CategoryName = "Sample Reports"
            });

            #endregion

            #region Update category

            var updateCategory = v2ApiObject.ItemsEndPoint().UpdateCategory(new ApiCategoryUpdate()
            {
                CategoryId = categoryId,
                Name = "update test"
            });

            #endregion

            #region Update report

            var updateReport = v2ApiObject.ItemsEndPoint().UpdateReport(new ApiReportUpdate()
            {
                ItemId = reportId,
                IsPublic = false,
                Name = "Testing report update",
                ItemContent = File.ReadAllBytes("../../Sales Order Detail.rdl")
            });

            #endregion

            #region Update datasource

            var updateDatasource = v2ApiObject.ItemsEndPoint().UpdateDataSource(new ApiReportDataSourceUpdate()
            {
                ItemId = datasourceId,
                Description = "testing"
            });

            #endregion

            #region Update file

            var updateWidget = v2ApiObject.ItemsEndPoint().UpdateFile(new ApiFileUpdate()
            {
                ItemId = fileDetails.Id,
                Description = "test",
                ItemContent = File.ReadAllBytes("../../sample file.txt")
            });

            #endregion

            #region Variable declaration to get favorite dashbaord

            var favoriteReportId = favoriteReports.Select(x => x.ReportId).FirstOrDefault();

            #endregion

            #region Update favorite report

            var updateFavoriteReport = v2ApiObject.ItemsEndPoint().UpdateFavoriteItem(new ApiUpdateFavoriteReport()
            {
                ReportId = favoriteReportId,
                Favorite = false
            });

            #endregion

            #region Export report

            // Export report to excel format

            var exportReportToExcel = v2ApiObject.ItemsEndPoint().ExportReport(new ApiExportReport()
            {
                ReportId = reportId,
                ExportType = ExportType.Excel.ToString()
            });

            // Export report to Pdf format

            var exportReportToPdf = v2ApiObject.ItemsEndPoint().ExportReport(new ApiExportReport()
            {
                ReportId = reportId,
                ExportType = ExportType.Pdf.ToString()
            });

            // Export report to word format

            var exportReportToWord = v2ApiObject.ItemsEndPoint().ExportReport(new ApiExportReport()
            {
                ReportId = reportId,
                ExportType = ExportType.Word.ToString()
            });

            // Export report to PPT format

            var exportReportToPPT = v2ApiObject.ItemsEndPoint().ExportReport(new ApiExportReport()
            {
                ReportId = reportId,
                ExportType = ExportType.PPT.ToString()
            });

            // Export report to CSV format

            var exportReportToCSV = v2ApiObject.ItemsEndPoint().ExportReport(new ApiExportReport()
            {
                ReportId = reportId,
                ExportType = ExportType.CSV.ToString()
            });

            // Export report to HTML format

            var exportReportToHTML = v2ApiObject.ItemsEndPoint().ExportReport(new ApiExportReport()
            {
                ReportId = reportId,
                ExportType = ExportType.Html.ToString()
            });

            #endregion

            #region Delete item

            // Delete report

            var deleteReport = v2ApiObject.ItemsEndPoint().DeleteItem(reportId);

            // Delete category

            var deleteCategory = v2ApiObject.ItemsEndPoint().DeleteItem(categoryId);

            // Delete datasource

            var deleteDatasource = v2ApiObject.ItemsEndPoint().DeleteItem(datasourceId);

            // Delete dataset

            var deleteDataset = v2ApiObject.ItemsEndPoint().DeleteItem(datasetId);

            // Delete file

            var deleteFile = v2ApiObject.ItemsEndPoint().DeleteItem(fileId);

            // Delete schedule

            var deleteSchedule = v2ApiObject.ItemsEndPoint().DeleteItem(scheduleId);

            #endregion

            #region V2 USERS

            #region V2 Download CSV template

            var downloadCsvTemplate = v2ApiObject.UsersEndPoint2().DownloadCsvTemplate();

            #endregion

            #region V2 Add user

            var addUserWithPassword = v2ApiObject.UsersEndPoint2().AddUserV2(new ApiUserAdd()
            {
                Email = "testuser@sync.com",
                FirstName = "Test2 user",
                Username = "Testuser2",
                Password = "Testuser@1203"
            });

            #endregion

            #region V2 Add CSV user

            var addCsvUser = v2ApiObject.UsersEndPoint2().CsvUserImport(new ApiCsvUserImportRequest()
            {
                CsvFileContent = File.ReadAllBytes("../../CSV Users.csv")
            });

            #endregion

            #region V2 Get group details of particular user

            var groupDetailsOfUser = v2ApiObject.UsersEndPoint2().GetGroupsOfUser(name);

            #endregion

            #region V2 Activate or deactivate the user

            var activateUser = v2ApiObject.UsersEndPoint2().ActivateDeactivateuser(name,
                new ApiUserActivationRequest()
                {
                    Activate = true   // Status to activate or deactivate the user
                });

            #endregion

            #endregion

            #region V2 GROUPS

            #region V2 Add user to particular group

            var addUserToGroup = v2ApiObject.GroupsEndPoint2().AddUserToGroup(groupId,
            new ApiGroupUsers()
            {
                Id = new List<int> { 3, 4 } // List of user's id to be added to the group

            });

            #endregion

            #region V2 Delete user from particular group

            var deleteUserFromGroup = v2ApiObject.GroupsEndPoint2().DeleteUserFromGroup(groupId,
            new ApiGroupUsers()
            {
                Id = new List<int> { 3, 4 } //List of user's id to be deleted from the group
            });

            #endregion

            #endregion

            #region V2 PERMISSION

            #region V2 Get list of permissions of particular user

            var getUserPermission = v2ApiObject.PermissionsEndPoint().GetUserPermission(userId);

            #endregion

            #region V2 Get list of permissions of particular group

            var getGroupPermission = v2ApiObject.PermissionsEndPoint().GetGroupPermission(groupId);

            #endregion

            #region V2 Add permission to particular user

            var addUserPermission = v2ApiObject.PermissionsEndPoint().AddUserPermission(new ApiUserPermissionAdd()
            {
                PermissionAccess = PermissionAccess.Read.ToString(),
                UserId = 3,
                PermissionEntity = PermissionEntity.AllReports.ToString()
            });

            #endregion

            #region V2 Add permission to particular group

            var addGroupPermission = v2ApiObject.PermissionsEndPoint().AddGroupPermission(new ApiGroupPermissionAdd()
            {
                PermissionAccess = PermissionAccess.Create.ToString(),
                GroupId = 2,
                PermissionEntity = PermissionEntity.AllCategories.ToString()
            });

            #endregion

            #region Variable declaration to get permission id of users and groups

            var userPermissionId = getUserPermission.Where(x => x.UserId == userId).Select(x => x.PermissionId).FirstOrDefault(); // Assign first permission id of the first user

            var groupPermissionId = getGroupPermission.Where(x => x.GroupId == groupId).Select(x => x.PermissionId).FirstOrDefault(); // Assign first permission id of the first group

            #endregion

            #region V2 Delete specific user permission

            var deleteUserPermission = v2ApiObject.PermissionsEndPoint().DeleteUserPermission(userPermissionId);

            #endregion

            #region V2 Delete specific group permission

            var deleteGroupPermission = v2ApiObject.PermissionsEndPoint().DeleteGroupPermission(groupPermissionId);

            #endregion

            #endregion

            #endregion

            #region V3

            #region schedule

            var addSchedule = v3ApiObject.ScheduleEndPoint3().AddSchedule(new ApiScheduleRequest
            {
                Name = "sample schedule",
                ReportId = reportId,
                ExportType = "Pdf",
                StartTime = DateTime.UtcNow.AddHours(1).ToString("yyyy-mm-dd HH:mm:ss"),
                NeverEnd = true,
                EndAfterOccurrence = 0,
                ExternalRecipientsList = new List<string> { "rameshkumar.arumugam@syncfusion.com", "rmshkumar362@outlook.com" },
                ScheduleType = "Daily",
                DailySchedule = new ApiDailySchedule
                {
                    RecurrenceType = "EveryWeekday",
                    EveryNdays = 0,
                    EveryWeekday = true
                }
            });

            var updateSchedule = v3ApiObject.ScheduleEndPoint3().UpdateSchedule(scheduleId, new ApiScheduleRequest
            {
                Name = "sample schedule-update",
                ReportId = reportId,
                ExportType = "Word",
                StartTime = DateTime.Now.ToString("yyyy-mm-ddTHH:mm:ssZ"),
                NeverEnd = true,
                EndAfterOccurrence = 0,
                ExternalRecipientsList = new List<string> { "rameshkumar.arumugam@syncfusion.com" },
                ScheduleType = "Daily",
                DailySchedule = new ApiDailySchedule
                {
                    RecurrenceType = "EveryWeekday",
                    EveryNdays = 0,
                    EveryWeekday = true
                }
            });

            #endregion

            #endregion
        }
    }
}
