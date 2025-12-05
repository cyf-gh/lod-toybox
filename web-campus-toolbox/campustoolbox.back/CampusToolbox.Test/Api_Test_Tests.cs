using CampusToolbox.Model.Back.Account;
using CampusToolbox.Model.Security;
using CampusToolbox.Test;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace CampusToolbox.Tests.Api {
    public class FeatureConfirm {
        private readonly ITestOutputHelper output;

        public FeatureConfirm( ITestOutputHelper output ) {
            this.output = output;
        }
    }
}
