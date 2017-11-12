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
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Eyedia.Aarbac.Framework
{
    [DataContract]
    public class RbacTable
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string ObjectId { get; set; }

        [DataMember]
        public List<RbacColumn> Columns { get; set; }

        [DataMember]
        public List<RbacCondition> Conditions { get; set; }
        public RbacOrderBy OrderBy { get; }

        [DataMember]
        public List<RbacParameter> Parameters { get; set; }

        [DataMember]
        public List<RbacRelation> Relations { get; set; }

        [DataMember]
        public RbacDBOperations AllowedOperations { get; set; }
        public bool ReferencedOnly { get; internal set; }
        public string TempAlias { get; internal set; }

        public RbacTable(string objectId, string name,
            bool create = false, bool read = false, bool update = false, bool delete = false)
        {
            this.ObjectId = objectId;
            this.Name = name;
            this.Columns = new List<RbacColumn>();
            this.Conditions = new List<RbacCondition>();            
            this.Relations = new List<RbacRelation>();
            this.Parameters = new List<RbacParameter>();            
            this.AllowedOperations = Rbac.ParseOperations(create, read, update, delete);
        }

        public RbacTable(string objectId, string name,
           string create = "False", string read = "False", string update = "False", string delete = "False")
        {
            this.ObjectId = objectId;
            this.Name = name;
            this.Columns = new List<RbacColumn>();
            this.Conditions = new List<RbacCondition>();            
            this.Relations = new List<RbacRelation>();
            this.Parameters = new List<RbacParameter>();
            this.AllowedOperations = Rbac.ParseOperations(create, read, update, delete);
        }

        
        public string WhereClause
        {
            get
            {
                if (Conditions.Count == 0)
                    return string.Empty;
                else
                    return Conditions.Select(i => i.WhereClause).Aggregate((i, j) => i + " and " + j);

            }
        }
    }

}
