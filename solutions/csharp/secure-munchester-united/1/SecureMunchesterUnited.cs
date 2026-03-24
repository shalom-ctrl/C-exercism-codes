public class SecurityPassMaker
{
    public string GetDisplayName(TeamSupport support)
    {
        // If not Staff → too important
        if (support is not Staff staff)
        {
            return "Too Important for a Security Pass";
        }

        // If specific security subtypes → no priority text
        if (support is SecurityJunior || support is SecurityIntern || support is PoliceLiaison)
        {
            return staff.Title;
        }

        // If Security or other derived types → add priority
        if (support is Security)
        {
            return staff.Title + " Priority Personnel";
        }

        // Other Staff
        return staff.Title;
    }
}

/**** Please do not alter the code below ****/

public interface TeamSupport { string Title { get; } }

public abstract class Staff : TeamSupport { public abstract string Title { get; } }

public class Manager : TeamSupport { public string Title { get; } = "The Manager"; }

public class Chairman : TeamSupport { public string Title { get; } = "The Chairman"; }

public class Physio : Staff { public override string Title { get; } = "The Physio"; }

public class OffensiveCoach : Staff { public override string Title { get; } = "Offensive Coach"; }

public class GoalKeepingCoach : Staff { public override string Title { get; } = "Goal Keeping Coach"; }

public class Security : Staff { public override string Title { get; } = "Security Team Member"; }

public class SecurityJunior : Security { public override string Title { get; } = "Security Junior"; }

public class SecurityIntern : Security { public override string Title { get; } = "Security Intern"; }

public class PoliceLiaison : Security { public override string Title { get; } = "Police Liaison Officer"; }