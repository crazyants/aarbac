#region Copyright Notice
/* Copyright (c) 2017, Deb'jyoti Das - debjyoti@debjyoti.com
 All rights reserved.

 Redistribution and use in source and binary forms, with or without
 modification, are not permitted.Neither the name of the 
 'Deb'jyoti Das' nor the names of its contributors may be used 
 to endorse or promote products derived from this software without 
 specific prior written permission.

 THIS SOFTWARE IS PROVIDED BY Deb'jyoti Das 'AS IS' AND ANY
 EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 DISCLAIMED. IN NO EVENT SHALL Synechron Holdings Inc BE LIABLE FOR ANY
 DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */
#region Developer Information
/*
Author  - Debjyoti Das (debjyoti@debjyoti.com)
Created - 11/12/2017 3:31:31 PM
Description  - 
Modified By - 
Description  - 
*/
#endregion Developer Information

#endregion Copyright Notice
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Eyedia.Aarbac.Framework
{
    public class RbacRoleWeb
    {
        public RbacRoleWeb()
        { }

        public RbacRoleWeb(RbacRole role)
        {
            if (role == null)
                return;

            this.RoleId = role.RoleId;
            this.RbacId = role.RbacId;
            this.Name = role.Name;
            this.Description = role.Description;
            this.Entitlement = role.Entitlement;
            this.CrudPermissions = role.CrudPermissions;
            this.MetaDataRbac = role.MetaDataRbac;
            this.MetaDataEntitlements = role.MetaDataEntitlements;
        }

        [ReadOnly(true)]
        public int RoleId { get; set; }

        [ReadOnly(true)]
        public int RbacId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Browsable(false)]
        public string MetaDataRbac { get; set; }

        [Browsable(false)]
        public string MetaDataEntitlements { get; set; }

        [Browsable(false)]
        [XmlIgnore]
        public RbacEntitlement Entitlement { get; set; }

        [Browsable(false)]
        [XmlIgnore]
        public List<RbacTable> CrudPermissions { get; set; }

        public static RbacRole Get(RbacRoleWeb rbacRoleWeb)
        {
            RbacRole role = new RbacRole();
            role.RoleId = rbacRoleWeb.RoleId;
            role.RbacId = rbacRoleWeb.RbacId;
            role.Name = rbacRoleWeb.Name;
            role.Description = rbacRoleWeb.Description;
            role.MetaDataRbac = rbacRoleWeb.MetaDataRbac;
            role.MetaDataEntitlements = rbacRoleWeb.MetaDataEntitlements;
            role.Entitlement = rbacRoleWeb.Entitlement;
            role.CrudPermissions = rbacRoleWeb.CrudPermissions;
            return role;
        }
    }
}

