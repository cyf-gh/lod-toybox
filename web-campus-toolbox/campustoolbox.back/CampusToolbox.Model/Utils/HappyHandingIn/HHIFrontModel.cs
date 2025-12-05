using System;
using System.Collections.Generic;
using System.Text;

namespace CampusToolbox.Model.Front.Utils.HappyHandingIn {
    public class WorkViewModel {
        /// <summary>
        /// Assigned Handing In Task Name
        /// </summary>
        public string Name { get; set; }
        public int Id { get; set; }
        /// <summary>
        /// Description Of the Task.
        /// </summary>
        /// <example>
        /// 1 dog image. 2 cat images. Totally about 3 images.
        /// </example>
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
    }
}
