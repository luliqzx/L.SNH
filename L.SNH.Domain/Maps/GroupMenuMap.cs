using FluentNHibernate.Mapping;
using L.SNH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.SNH.Domain.Maps
{
    public class GroupMenuMap : ClassMap<GroupMenu>
    {
        public GroupMenuMap()
        {
            this.CompositeId()
                .KeyReference(x => x.Act, "ActId")
                .KeyReference(x => x.Menu, "MenuId");

            this.HasManyToMany(x => x.Privileges).Table("GroupMenuPrivilege").ParentKeyColumns.Add("ActId", "MenuId").ChildKeyColumn("PrivilegeId");
        }
    }
}
