using System.Collections.Generic;

namespace Nozarasius {
    public class PlayerState {
        
        public PlayerState()
        {
            foreach(var p in PlayerControl.AllPlayerControls)
            {
                players.Add(p.PlayerId);
                isDead.Add(p.PlayerId,false);
                deathReasons.Add(p.PlayerId,DeathReason.etc);
            }
        }
        public List<byte> players = new List<byte>();
        public Dictionary<byte,bool> isDead = new Dictionary<byte, bool>();
        public Dictionary<byte,DeathReason> deathReasons = new Dictionary<byte, DeathReason>();
        public void setDeathReason(byte p, DeathReason reason) { deathReasons[p] = reason; }
        public DeathReason getDeathReason(byte p) { return deathReasons[p]; }
        public bool isSuicide(byte p) { return deathReasons[p] == DeathReason.Suicide; }
        
        public enum DeathReason
        {
            Kill,
            Vote,
            Suicide,
            Spell,
            Bombed,
            etc = -1
        }
    }
    public class TaskState {
        public int AllTasksCount;
        public int CompletedTasksCount;
        public bool hasTasks;
        public int RemainingTasksCount => AllTasksCount - CompletedTasksCount;
        public bool doExpose => RemainingTasksCount <= Nozarasius.SnitchExposeTaskLeft && hasTasks;
        public bool isTaskFinished => RemainingTasksCount <= 0 && hasTasks;
        public TaskState(int all, int completed) {
            this.AllTasksCount = all;
            this.CompletedTasksCount = completed;
            this.hasTasks = true;
        }
        public TaskState() {
            this.AllTasksCount = 0;
            this.CompletedTasksCount = 0;
            this.hasTasks = false;
        }
    }
}
