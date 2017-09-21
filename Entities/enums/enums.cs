using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.enums
{
    public enum DateTransportTypeEnum
    {
        Fixed,
        Opened,
        Description
    }

    public enum RequestStateEnum
    {
        Published,
        Closed,
        Interrupted
    }

    public enum ErrorsEnum
    {
        GENERIC_ERROR,
        EMAIL_ALREADY_PRESENT,
        UNAUTHORIZED_REQUEST,
        USERNAME_ALREADY_PRESENT,
        USER_ROLE_ALREADY_PRESENT,
        COMPANY_ALREADY_PRESENT,
        LAST_USER_ROLE,
        REMOVE_DEFAULT_USER_ROLE,
        OPERATION_NOT_PERMITTED_ON_COMPANY,
        UNABLE_DELETE_COMPANY_WITH_CHILD,
        UNABLE_DELETE_COMPANY_WITH_USERS,
        LOAD_PHOTO_PROBLEM,
        DOCUMENT_WAS_CLOSED,
        SIGN_DOCUMENT_ERROR,
        UNABLE_TO_UPLOAD_ON_N4D,
        UNABLE_TO_CONFIRM_POD,
        UNABLE_TO_LOAD_DOCUMENT,
        UNBLE_TO_UPDATE_ROW_STATE,
        LOGIN_INVALID_MODEL,
        LOGIN_USER_PSWD_WRONG,
        DEVICE_OFFLINE,
        ADDRESS_ADD_ERROR,
        USER_NOT_PRESENT
    };

    public enum ActionEnum
    {
        ALL = 0
    };

}
