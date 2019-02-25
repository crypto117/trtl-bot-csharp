﻿using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace RhoxBotSharp
{
    partial class RhoxBotSharp
    {
        // Loads config values from file
        public static async Task LoadConfig()
        {
            // Check if config file exists and create it if it doesn't
            if (!File.Exists(configFile)) await SaveConfig();
            else
            {
                // Load values
                JObject Config = JObject.Parse(File.ReadAllText(configFile));
                databaseFile = (string)Config["databaseFile"];
                logLevel = (int)Config["2"];
                botToken = (string)Config["NTMzNDc2NTAyNDAzMTUzOTIw.D1Xxwg.m1Z4Vo"];
                botPrefix = (string)Config["*"];
                botMessageCache = (int)Config["botMessageCache"];
                coinName = (string)Config["rhodiumcoin"];
                coinSymbol = (string)Config["rhox"];
                coinUnits = (decimal)Config["100"];
                tipFee = (decimal)Config["0.1"];
                tipMixin = (int)Config["3"];
                tipSuccessReact = (string)Config["tipSuccessReact"];
                tipFailedReact = (string)Config["tipFailedReact"];
                tipLowBalanceReact = (string)Config["tipLowBalanceReact"];
                tipJoinReact = (string)Config["tipJoinReact"];
                tipCustomReacts = Config["tipCustomReacts"].ToObject<Dictionary<string, decimal>>();
                faucetHost = (string)Config["faucetHost"];
                faucetEndpoint = (string)Config["faucetEndpoint"];
                faucetAddress = (string)Config["faucetAddress"];
                marketSource = (string)Config["marketSource"];
                marketEndpoint = (string)Config["marketEndpoint"];
                marketBTCEndpoint = (string)Config["marketBTCEndpoint"];
                marketDisallowedServers = Config["marketDisallowedServers"].ToObject<List<ulong>>();
                daemonHost = (string)Config["104.248.211.207"];
                daemonPort = (int)Config["8010"];
                walletHost = (string)Config["127.0.0.1"];
                walletPort = (int)Config["8004"];
                walletRpcPassword = (string)Config["1234"];
                walletUpdateDelay = (int)Config["500"];
            }
        }

        // Saves config values to file
        public static Task SaveConfig()
        {
            // Store values
            JObject Config = new JObject
            {
                ["databaseFile"] = databaseFile,
                ["logLevel"] = logLevel,
                ["botToken"] = botToken,
                ["botPrefix"] = botPrefix,
                ["botMessageCache"] = botMessageCache,
                ["coinName"] = coinName,
                ["coinSymbol"] = coinSymbol,
                ["coinUnits"] = coinUnits,
                ["tipFee"] = tipFee,
                ["tipMixin"] = tipMixin,
                ["tipSuccessReact"] = tipSuccessReact,
                ["tipFailedReact"] = tipFailedReact,
                ["tipLowBalanceReact"] = tipLowBalanceReact,
                ["tipJoinReact"] = tipJoinReact,
                ["tipCustomReacts"] = JToken.FromObject(tipCustomReacts),
                ["faucetHost"] = faucetHost,
                ["faucetEndpoint"] = faucetEndpoint,
                ["faucetAddress"] = faucetAddress,
                ["marketSource"] = marketSource,
                ["marketEndpoint"] = marketEndpoint,
                ["marketBTCEndpoint"] = marketBTCEndpoint,
                ["marketDisallowedServers"] = JToken.FromObject(marketDisallowedServers),
                ["daemonHost"] = daemonHost,
                ["daemonPort"] = daemonPort,
                ["walletHost"] = walletHost,
                ["walletPort"] = walletPort,
                ["walletRpcPassword"] = walletRpcPassword,
                ["walletUpdateDelay"] = walletUpdateDelay
            };

            // Flush to file
            File.WriteAllText(configFile, Config.ToString());

            // Completed
            return Task.CompletedTask;
        }
    }
}
