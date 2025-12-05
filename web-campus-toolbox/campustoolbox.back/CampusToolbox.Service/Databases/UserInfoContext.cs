using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampusToolbox.Service.Databases {
    public class UserInfoContext : DbContext {
        public UserInfoContext( DbContextOptions<HHIContext> options ) : base( options ) { }

    }
}
