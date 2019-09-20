using System;
using System.Data;
using System.Text;

namespace TableLib.DB.Entitys
{
    /// <summary>
    /// 类TaskScriptTree。
    /// </summary>
    [Serializable]
    public partial class TaskScriptTree : IEntity
    {
        public TaskScriptTree() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("ID", ID);
            query.set("Name", Name);
            query.set("Parent", Parent);
            query.set("Status", Status);

            return query;
        }

        public string ID { get; set; }
        public string Name { get; set; }
        public string Parent { get; set; }
        public int Status { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            ID = source("ID").value<string>(Guid.NewGuid().ToString());
            Name = source("Name").value<string>("");
            Parent = source("Parent").value<string>("");
            Status = source("Status").value<int>(0);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new TaskScriptTree();
        }
    }
}