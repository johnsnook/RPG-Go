using RPG_Go;
using System;

namespace RPG_Go
{
    /// <summary>
    /// Base effect class
    /// </summary>
    public class Effect
    {
        //public Object Parent;
        public virtual string Name { get; protected internal set; }

        public virtual string Description { get; protected internal set; }
        public virtual string EventName { get; protected internal set; }
    }

    /// <summary>
    /// This class uses tokenized psuedu code and parses it on the action
    /// </summary>
    public class TokenizedEffect : Effect
    {
        protected string[] _actionTokens;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Effect name</param>
        /// <param name="description">optional</param>
        /// <param name="eventName">the name of the event to attach to, eg LevelUp, Attack</param>
        /// <param name="action">a space seperate command in token form</param>
        public TokenizedEffect(string name, string description, string eventName, string action)
        {
            Name = name;
            Description = description;
            EventName = eventName;
            char[] bs = { ' ' };
            _actionTokens = action.Split(bs);
        }

        public void AttachEvent(Character publisher)
        {
            switch (EventName)
            {
                case "Create":
                    publisher.Create += OnApply;
                    break;

                case "LevelUp":
                    publisher.LevelUp += OnApply;
                    break;
            }
        }

        //  A
        public void OnApply(object Sender, EventArgs e)
        {
            // parse it
            switch (_actionTokens[0])
            {
            }
        }
    }

    /// <summary>
    /// This class provides Apply
    /// </summary>
    public class DelegatedEffect : Effect
    {
        //// Attach the effect to be applied to this code, you can even use a anonymous func
        //public delegate void OnApply(object sender, EventArgs e);

        protected string[] _actionTokens;

        /// <summary>
        /// Constructor to which you pass your event handler
        /// </summary>
        /// <param name="Publisher"></param>
        /// <param name="action"></param>
        public DelegatedEffect(Character Publisher, string name, string description, string eventName)
        {
            Name = name;
            Description = description;
            EventName = eventName;
            //OnApply = action;
        }

        /// Attach the event handler (action) to the appropriate publisher event
        public void AttachEvent(Character publisher, EventHandler action)
        {
            switch (EventName)
            {
                case "Create":
                    publisher.Create += action;
                    break;

                case "LevelUp":
                    publisher.LevelUp += action;
                    break;
            }
        }
    }
}