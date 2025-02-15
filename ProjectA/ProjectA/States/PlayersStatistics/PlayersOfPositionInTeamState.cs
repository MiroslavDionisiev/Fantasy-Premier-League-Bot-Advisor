﻿using ProjectA.Models.StateOfChatModels.Enums;
using ProjectA.Services.StateProvider;
using ProjectA.Services.Statistics;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using System.Text;
using static ProjectA.States.StateConstants;
using System.Linq;
using ProjectA.Models.PlayersModels;
using ProjectA.Infrastructure;

namespace ProjectA.States.PlayersStatistics
{
    public class PlayersOfPositionInTeamState : IState
    {
        private readonly ICosmosDbStateProviderService _stateProvider;
        private readonly IStatisticsService _statisticsService;

        public PlayersOfPositionInTeamState(ICosmosDbStateProviderService stateProvider, IStatisticsService statisticsService)
        {
            this._stateProvider = stateProvider;
            this._statisticsService = statisticsService;
        }

        private async Task<string> HandleRequest(ITelegramBotClient botClient, Message message, string teamName, string position)
        {
            var result = await this._statisticsService.GetPLayersOfPositionInTeamAsync(teamName, position);
            if (result == null)
            {
                return "Wrong team name or position";
            }

            StringBuilder stringBuilder = new StringBuilder();
            int counter = 1;
            stringBuilder.Append($"Player Name");
            foreach (Element player in result)
            {
                stringBuilder.Append($"{counter}. {KeyBuilder.Build(player.First_Name, player.Second_Name)}");
                stringBuilder.AppendLine();
                counter++;
            }

            return stringBuilder.ToString();
        }

        private string[] HandleInput(string inputText)
        {
            string[] splited = inputText.Split(' ');
            string[] result = new string[2];
            result[0] = string.Join(" ", splited.Take(splited.Length - 1));
            result[1] = splited.Last();
            return result;
        }

        public async Task<StateType> BotOnCallBackQueryReceived(ITelegramBotClient botClient, CallbackQuery callbackQuery)
        {
            await botClient.AnswerCallbackQueryAsync(callbackQueryId: callbackQuery.Id);

            return StateType.PlayersOfPositionInTeamState;
        }

        public async Task<StateType> BotOnMessageReceived(ITelegramBotClient botClient, Message message)
        {
            if (message.Text == null)
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, StateMessages.InsertPlayersSuggestionsPreferences);
                return StateType.StatisticsMenuState;
            }

            string[] splittedInput = this.HandleInput(message.Text);
            string teamName = splittedInput[0];
            string position = splittedInput[1];

            string result = await this.HandleRequest(botClient, message, teamName, position);
            await botClient.SendTextMessageAsync(message.Chat.Id, result);

            return StateType.StatisticsMenuState;
        }

        public async Task BotSendMessage(ITelegramBotClient botClient, long chatId)
        {
            await botClient.SendTextMessageAsync(chatId, StateMessages.InsertPlayersSuggestionsPreferences);
        }
    }
}
