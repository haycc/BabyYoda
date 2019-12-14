﻿using System;
using BabyYodaBot.Core;
using BabyYodaBot.Core.Handlers;
using BabyYodaBot.Core.Net;
using BabyYodaBot.Core.BabyYoda;
using BabyYodaBot.Core.BabyYoda.Commands;
using BabyYodaBot.Core.Twitch;

namespace BabyYodaBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var ioc = new IoC();
            ioc.RegisterCustomShared<IoC>(() => ioc);
            ioc.RegisterShared<ILogger, ConsoleLogger>();
            ioc.RegisterShared<IKernel, Kernel>();

            ioc.RegisterShared<ITwitchUserStore, TwitchUserStore>();
            ioc.RegisterCustomShared<IAppSettings>(() => new AppSettingsProvider().Get());
            ioc.Register<IGameConnection, TcpGameConnection>();
            ioc.Register<IGameClient, TcpGameClient>();

            ioc.RegisterShared<IMessageBus, MessageBus>();
            ioc.RegisterShared<IChannelProvider, DefaultChannelProvider>();
            ioc.RegisterShared<IConnectionCredentialsProvider, DefaultConnectionCredentialsProvider>();
            ioc.RegisterShared<ICommandHandler, DefaultTextCommandHandler>();

            ioc.RegisterShared<IGameClient, TcpGameClient>();
            ioc.RegisterShared<IGameClient2, TcpGameClient>();
            ioc.RegisterShared<IGameClient3, TcpGameClient>();
            ioc.RegisterShared<IGameClient4, TcpGameClient>();

            ioc.RegisterShared<IPlayerProvider, PlayerProvider>();

            ioc.RegisterShared<ICommandListener, TwitchCommandListener>();
            ioc.RegisterShared<IBabyYodaClient, UnityBabyYodaClient>();

            using (var cmdListener = ioc.Resolve<ICommandListener>())
            {
                cmdListener.Start();

                while (true)
                {
                    if (Console.ReadKey().Key == ConsoleKey.Q)
                    {
                        break;
                    }
                }

                cmdListener.Stop();
            }
        }
    }
}
