﻿#region Reference
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplePIM.Configs;
#endregion

namespace SimplePIM.General
{
    public class InstructionBlock : InputType
    {
        public int ins_count=> ins.Count();
        public List<Instruction> ins = new List<Instruction>();
        public UInt64 servetime=NULL;
        public string name = "";
        public override ulong Length()
        {
            return Config.operationcode_length * (uint)ins_count;
        }

        public void add_ins(Instruction ins_)
        {
            if (ins.Count == 0)
                cycle = ins_.cycle;
            ins.Add(ins_);
        }
        public Instruction get_ins(UInt64 cycle)
        {
            if (ins.Count > 0)
            {
                if (ins[0].cycle <= cycle)
                {
                    if (servetime == NULL)
                        servetime = cycle;
                    var item = ins[0];
                    ins.RemoveAt(0);
                    return item;
                }
                else
                    return new Instruction();
            }
            else
            {
                return null;
            }
        }
    }
}
