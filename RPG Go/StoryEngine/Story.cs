using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG_Go.StoryEngine
{
    public class Story
    {
        public int Id;
        public string Name;
        public int MinumumLevel;
        public StoryElement FirstElement;
        private List<StoryElement> storyElements;

        public List<StoryElement> StoryElements { get { return storyElements; } }
    }

    public class StoryElement
    {
        public int Id;
        private string text;
    }
}