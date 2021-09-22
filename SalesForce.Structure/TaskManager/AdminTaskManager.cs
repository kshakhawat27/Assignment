using SalesForce.Server.BLL.Admin;
using SalesForce.Server.BLL.Inventory;
using System;

namespace SalesForce.Structure.TaskManager
{
    internal class AdminTaskManager
    {
        public object Execute(string methodName, object param)
        {
            switch (methodName)
            {
                #region Auto Generated - ADM_User
                case ERPTask.AG_SaveAdmUserInfo:
                    AdmUserBLL admUserBLL = null;
                    admUserBLL = new AdmUserBLL();
                    return admUserBLL.SaveAdmUserInfo(param);
                    break;
                case ERPTask.AG_UpdateAdmUserInfo:
                    admUserBLL = new AdmUserBLL();
                    return admUserBLL.UpdateAdmUserInfo(param);
                    break;
                case ERPTask.AG_DeleteAdmUserInfoById:
                    admUserBLL = new AdmUserBLL();
                    return admUserBLL.DeleteAdmUserInfoById(param);
                    break;
                case ERPTask.AG_GetAllAdmUserRecord:
                    admUserBLL = new AdmUserBLL();
                    return admUserBLL.GetAllAdmUserRecord(param);
                    break;
                case ERPTask.AG_GetSingleAdmUserRecordById:
                    admUserBLL = new AdmUserBLL();
                    return admUserBLL.GetSingleAdmUserRecordById(param);
                    break;
                #endregion

                #region Auto Generated - ADM_MasterFeature
                case ERPTask.AG_SaveAdmMasterfeatureInfo:
                    AdmMasterfeatureBLL admMasterfeatureBLL = null;
                    admMasterfeatureBLL = new AdmMasterfeatureBLL();
                    return admMasterfeatureBLL.SaveAdmMasterfeatureInfo(param);
                    break;
                case ERPTask.AG_UpdateAdmMasterfeatureInfo:
                    admMasterfeatureBLL = new AdmMasterfeatureBLL();
                    return admMasterfeatureBLL.UpdateAdmMasterfeatureInfo(param);
                    break;
                case ERPTask.AG_DeleteAdmMasterfeatureInfoById:
                    admMasterfeatureBLL = new AdmMasterfeatureBLL();
                    return admMasterfeatureBLL.DeleteAdmMasterfeatureInfoById(param);
                    break;
                case ERPTask.AG_GetAllAdmMasterfeatureRecord:
                    admMasterfeatureBLL = new AdmMasterfeatureBLL();
                    return admMasterfeatureBLL.GetAllAdmMasterfeatureRecord(param);
                    break;
                case ERPTask.AG_GetSingleAdmMasterfeatureRecordById:
                    admMasterfeatureBLL = new AdmMasterfeatureBLL();
                    return admMasterfeatureBLL.GetSingleAdmMasterfeatureRecordById(param);
                    break;
                #endregion

                #region Auto Generated - ADM_SubFeature
                case ERPTask.AG_SaveAdmSubfeatureInfo:
                    AdmSubfeatureBLL admSubfeatureBLL = null;
                    admSubfeatureBLL = new AdmSubfeatureBLL();
                    return admSubfeatureBLL.SaveAdmSubfeatureInfo(param);
                    break;
                case ERPTask.AG_UpdateAdmSubfeatureInfo:
                    admSubfeatureBLL = new AdmSubfeatureBLL();
                    return admSubfeatureBLL.UpdateAdmSubfeatureInfo(param);
                    break;
                case ERPTask.AG_DeleteAdmSubfeatureInfoById:
                    admSubfeatureBLL = new AdmSubfeatureBLL();
                    return admSubfeatureBLL.DeleteAdmSubfeatureInfoById(param);
                    break;
                case ERPTask.AG_GetAllAdmSubfeatureRecord:
                    admSubfeatureBLL = new AdmSubfeatureBLL();
                    return admSubfeatureBLL.GetAllAdmSubfeatureRecord(param);
                    break;
                case ERPTask.AG_GetSingleAdmSubfeatureRecordById:
                    admSubfeatureBLL = new AdmSubfeatureBLL();
                    return admSubfeatureBLL.GetSingleAdmSubfeatureRecordById(param);
                    break;
                #endregion

                #region Auto Generated - ADM_UserPermission
                case ERPTask.AG_SaveAdmUserpermissionInfo:
                    AdmUserpermissionBLL admUserpermissionBLL = null;
                    admUserpermissionBLL = new AdmUserpermissionBLL();
                    return admUserpermissionBLL.SaveAdmUserpermissionInfo(param);
                    break;
                case ERPTask.AG_UpdateAdmUserpermissionInfo:
                    admUserpermissionBLL = new AdmUserpermissionBLL();
                    return admUserpermissionBLL.UpdateAdmUserpermissionInfo(param);
                    break;
                case ERPTask.AG_DeleteAdmUserpermissionInfoById:
                    admUserpermissionBLL = new AdmUserpermissionBLL();
                    return admUserpermissionBLL.DeleteAdmUserpermissionInfoById(param);
                    break;
                case ERPTask.AG_GetAllAdmUserpermissionRecord:
                    admUserpermissionBLL = new AdmUserpermissionBLL();
                    return admUserpermissionBLL.GetAllAdmUserpermissionRecord(param);
                    break;
                case ERPTask.AG_GetSingleAdmUserpermissionRecordById:
                    admUserpermissionBLL = new AdmUserpermissionBLL();
                    return admUserpermissionBLL.GetSingleAdmUserpermissionRecordById(param);
                    break;
                #endregion
                #region Auto Generated - ADM_Attendance
                case ERPTask.AG_SaveAttendanceInfo:

                    AttendanceBLL AttendanceBLL = null;
                    AttendanceBLL = new AttendanceBLL();
                    return AttendanceBLL.SaveAttendanceInfo(param);
                    break;
                case ERPTask.AG_UpdateAttendanceInfo:
                    AttendanceBLL = new AttendanceBLL();
                    return AttendanceBLL.UpdateAttendanceInfo(param);
                    break;

                #endregion

                default:
                    break;
            }
            return null;
        }
        public object Execute(string methodName)
        {
            throw new NotImplementedException();
        }

        // Hello
    }
}
