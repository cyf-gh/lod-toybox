using CampusToolbox.Model;
using CampusToolbox.Model.Back.Utils.HappyHandingIn;
using CampusToolbox.Model.Front.Utils.HappyHandingIn;
using CampusToolbox.Service.Databases;
using CampusToolbox.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using static CampusToolbox.Model.Back.Utils.HappyHandingIn.HHIModel;

namespace CampusToolbox.Service.HHI {
    public interface IHHIService : IService {
        HHIContext GetContext();
        HHIFrontViewModel GetViewModel( HHIFrontFetchCommitsModel fetchCommits, ITokenService tokenService, HttpRequest request );
        void CommitImages( HHIFrontUploadImageModel uploadImageModel, ITokenService tokenService, HttpRequest request );
        HHIBackModel FindBackModelByInfos( int taskId, int ownerId );

        /// <summary>
        /// Get HHI Model
        /// </summary>
        /// <returns>
        /// <see cref="CampusToolbox.Model.HHI.HHIModel"/>
        /// </returns>
        HHIModel GetHHIModel();
        void AdminUpdatePrefixs( PrefixModel prefix );
        void AdminUpdateTasks( AssignedTaskModel task );
        /*
/// <summary>
/// Get HHI User Model
/// </summary>
/// <returns>
/// <see cref="CampusToolbox.Model.HHI.HHIUserModel"/>
/// </returns>
IModel GetUserModel();
*/
    }
}
