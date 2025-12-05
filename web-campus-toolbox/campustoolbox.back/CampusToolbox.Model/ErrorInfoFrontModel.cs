using System;
using System.Collections.Generic;
using System.Text;

namespace CampusToolbox.Model.Front {
    public enum ErrorInfoCode : int {
        Unknown = -99999,
        InvalidToken,
        NoToken,
        InvalidContent,
        NoSuchUser,
        PasswordOrAccountNameWrong,
        FailedToReset,
        AccountExisted,
        NotImplementedApi
    }
    public class ErrorInfoFrontModel {
        public ErrorInfoCode ErrorCode { get; set; }
        public string Detail { get; set; }
    }
}
