﻿using System.Globalization;
using GitSelfie.Domain.Interfaces;
using GitSelfie.Domain.Models;

namespace GitSelfie.Commands
{
    public static class CommandFactory
    {
        public static ICommand Create(string[] args)
        {
            if (args.Length == 1 && args[0].ToLower(CultureInfo.CurrentCulture) == "init")
            {
                return new InitCommand();
            }

            if (args.Length == 1 && args[0].ToLower(CultureInfo.CurrentCulture) == "rm")
            {
                return new RemoveCommand();
            }

            if (args.Length == 1 && args[0].ToLower(CultureInfo.CurrentCulture) == "/h")
            {
                return new HelpCommand();
            }

            if (args.Length >= 2)
            {
                var commit = LoadCommitData(args);
                return new SelfieCommand(commit);
            }

            return null;
        }

        private static Commit LoadCommitData(string[] args)
        {
            var data = new Commit
            {
                Message = args[0],
                Sha1 = args[1]
            };

            if (data.Sha1.Length > 20)
            {
                data.Sha1 = data.Sha1.Substring(0, 20);
            }

            return data;
        } 
    }
}