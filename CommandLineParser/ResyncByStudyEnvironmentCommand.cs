using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace CommandLineParser
{
    public class ResyncByStudyEnvironmentCommand : Command
    {
        public ResyncByStudyEnvironmentCommand() : 
            base("ResyncByStudyEnvironment", "Resynchronize all user roles under StudyEnvironment")
        {
            AddOption(new Option<Guid>("--user", "User UUID"));
            AddOption(new Option<Guid>("--study-environment", "StudyEnvironment UUID"));
            
            Handler = CommandHandler.Create(
                (Guid user, Guid studyEnvironment) => HandleCommand(user,studyEnvironment));
        }

        private void HandleCommand (Guid user, Guid studyEnvironment)
        {
            Console.WriteLine($"User: {user}");
            Console.WriteLine($"StudyEnvironment: {studyEnvironment}");
        }
    }
}
