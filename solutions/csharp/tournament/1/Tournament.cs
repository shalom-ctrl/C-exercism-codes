using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public static class Tournament
{
    private class TeamStats
    {
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int MatchesPlayed => Wins + Draws + Losses;
        public int Points => (Wins * 3) + (Draws * 1);
    }

    public static void Tally(Stream inStream, Stream outStream)
    {
        var teams = new Dictionary<string, TeamStats>();
        using var reader = new StreamReader(inStream);

        string line;
        while ((line = reader.ReadLine()) != null)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            var parts = line.Split(';');
            var teamAName = parts[0];
            var teamBName = parts[1];
            var result = parts[2];

            if (!teams.ContainsKey(teamAName)) teams[teamAName] = new TeamStats { Name = teamAName };
            if (!teams.ContainsKey(teamBName)) teams[teamBName] = new TeamStats { Name = teamBName };

            switch (result)
            {
                case "win":
                    teams[teamAName].Wins++;
                    teams[teamBName].Losses++;
                    break;
                case "loss":
                    teams[teamAName].Losses++;
                    teams[teamBName].Wins++;
                    break;
                case "draw":
                    teams[teamAName].Draws++;
                    teams[teamBName].Draws++;
                    break;
            }
        }

        // Sort: Points DESC, then Name ASC
        var sortedTeams = teams.Values
            .OrderByDescending(t => t.Points)
            .ThenBy(t => t.Name)
            .ToList();

        // Prepare the output table
        var sb = new StringBuilder();
        sb.Append("Team                           | MP |  W |  D |  L |  P");

        foreach (var team in sortedTeams)
        {
            sb.Append($"\n{team.Name,-30} | {team.MatchesPlayed,2} | {team.Wins,2} | {team.Draws,2} | {team.Losses,2} | {team.Points,2}");
        }

        using var writer = new StreamWriter(outStream);
        writer.Write(sb.ToString());
    }
}