using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace CommandLineParser
{
    public class ResyncByStudyEnvironmentSiteCommand : Command
    {
        public ResyncByStudyEnvironmentSiteCommand() : 
            base("ResyncByStudyEnvironmentSite", "Resynchronize all user roles under StudyEnvironmentSite")
        {
            AddOption(new Option<Guid>("--user", "User UUID"));
            AddOption(new Option<Guid>("--study-environment", "StudyEnvironment UUID"));
            AddOption(new Option<Guid>("--configuration-type-role", "ConfigurationTypeRole UUID"));
            AddOption(new Option<Guid>("--study-environment-site", "StudyEnvironmentSite UUID"));

            Handler = CommandHandler.Create(
                (Guid user, Guid studyEnvironment, Guid configurationTypeRole, Guid studyEnvironmentSite) => 
                    HandleCommand(user,studyEnvironment, configurationTypeRole, studyEnvironmentSite));
        }

        private void HandleCommand (
            Guid user, Guid studyEnvironment, Guid configurationTypeRole, Guid studyEnvironmentSite)
        {
            Console.WriteLine($"User: {user}");
            Console.WriteLine($"StudyEnvironment: {studyEnvironment}");
            Console.WriteLine($"ConfigurationTypeRole: {configurationTypeRole}");
            Console.WriteLine($"StudyEnvironmentSite: {studyEnvironmentSite}");
        }
    }
}
