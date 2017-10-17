using Cacm.Isils.Model.Base;
using Cacm.Isils.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cacm.Isils.ViewModel
{
    /// <summary>
    /// student list view model
    /// </summary>
    /// <seealso cref="Cacm.Isils.Model.Base.BaseViewModel" />
    class StudentListViewModel :BaseViewModel
    {
        /// <summary>
        /// Gets or sets the studdent.
        /// </summary>
        /// <value>
        /// The studdent.
        /// </value>
        public List<StudentListItemViewModel> Students { get; set; }
    }
}
