﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;

namespace MobileKidsIdApp.Models
{
    [Serializable]
    public class FamilyMemberList : BusinessListBase<FamilyMemberList, FamilyMember>
    {
        protected override FamilyMember AddNewCore()
        {
            var nextId = 0;
            if (this.Count > 0)
                nextId = this.Max(r => r.Id) + 1;

            var result = DataPortal.CreateChild<FamilyMember>(nextId);
            Add(result);
            return result;
        }

        private void Child_Fetch(List<DataAccess.DataModels.FamilyMember> list)
        {
            foreach (var item in list)
                Add(DataPortal.FetchChild<FamilyMember>(item));
        }
    }
}
