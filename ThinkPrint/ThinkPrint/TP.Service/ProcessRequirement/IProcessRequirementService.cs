using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.ProcessRequirement {

    public interface IProcessRequirementService {
        PMW_ProcessRequirement GetProcessRequirement(int  ProcessRequirementId);
        List<PMW_ProcessRequirement> GetProcessRequirements();
        PagedList<PMW_ProcessRequirement> GetProcessRequirements(int pageIndex, int pageSize, string searchKey = null);
        void InsertProcessRequirement(PMW_ProcessRequirement ProcessRequirement);
        void UpdateProcessRequirement(PMW_ProcessRequirement ProcessRequirement);
        void DeleteProcessRequirement(PMW_ProcessRequirement ProcessRequirement);
    }
}

