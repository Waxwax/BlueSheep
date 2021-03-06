









// Generated on 12/11/2014 19:01:36
using System;
using System.Collections.Generic;
using System.Linq;
using BlueSheep.Common.Protocol.Types;
using BlueSheep.Common.IO;
using BlueSheep.Engine.Types;

namespace BlueSheep.Common.Protocol.Messages
{
    public class ObjectGroundListAddedMessage : Message
    {
        public new const uint ID =5925;
        public override uint ProtocolID
        {
            get { return ID; }
        }
        
        public short[] cells;
        public short[] referenceIds;
        
        public ObjectGroundListAddedMessage()
        {
        }
        
        public ObjectGroundListAddedMessage(short[] cells, short[] referenceIds)
        {
            this.cells = cells;
            this.referenceIds = referenceIds;
        }
        
        public override void Serialize(BigEndianWriter writer)
        {
            writer.WriteUShort((ushort)cells.Length);
            foreach (var entry in cells)
            {
                 writer.WriteVarShort(entry);
            }
            writer.WriteUShort((ushort)referenceIds.Length);
            foreach (var entry in referenceIds)
            {
                 writer.WriteVarShort(entry);
            }
        }
        
        public override void Deserialize(BigEndianReader reader)
        {
            var limit = reader.ReadUShort();
            cells = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 cells[i] = reader.ReadVarShort();
            }
            limit = reader.ReadUShort();
            referenceIds = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 referenceIds[i] = reader.ReadVarShort();
            }
        }
        
    }
    
}