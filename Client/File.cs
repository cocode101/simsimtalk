using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class File
    {
        private int roomNumber;
        private List<string> fileName = new List<string>();
        private List<string> filePath = new List<string>();

        public int getRoomNumber() { return roomNumber; }
        public List<string> getFileName() { return fileName; }
        public List<string> getFilePath() { return filePath; }

        public void setRoomNumber(int roomNumber) { this.roomNumber = roomNumber; }
        public void setFileName(List<string> fileName) { this.fileName = fileName; }
        public void setFilePath(List<string> filePath) { this.filePath = filePath; }
    }
}
