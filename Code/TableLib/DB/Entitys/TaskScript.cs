using System;
using System.Data;
using System.Text;

namespace TableLib.DB.Entitys
{
    /// <summary>
    /// 类TaskScript。
    /// </summary>
    [Serializable]
    public partial class TaskScript : IEntity
    {
        public TaskScript() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("ID", ID);
            query.set("TreeID", TreeID);
            query.set("Name", Name);
            query.set("Range", Range);
            query.set("Script", Script);
            query.set("ModifyTime", ModifyTime);
            query.set("Status", Status);

            return query;
        }

        public string ID { get; set; }
        public string TreeID { get; set; }
        public string Name { get; set; }
        public string Range { get; set; }
        public string Script { get; set; }
        public DateTime ModifyTime { get; set; }
        public int Status { get; set; }

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            ID = source("ID").value<string>(Guid.NewGuid().ToString());
            TreeID = source("TreeID").value<string>("");
            Name = source("Name").value<string>("");
            Range = source("Range").value<string>("");
            Script = source("Script").value<string>("");
            ModifyTime = source("ModifyTime").value<DateTime>(DateTime.Now);
            Status = source("Status").value<int>(0);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new TaskScript();
        }
    }
}