using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.MVC.Areas.ViewModels.BaseVms
{
    public class BaseEntityAreaVm
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
