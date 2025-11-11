namespace RandomCinema.Application.Utils;

public class ProbabilitiesCalculator
{
    // Applies the Rule of Succession to calculate a movie rating with Bayesian adjustment.
    public static double RuleOfSuccession(double score, int samples)
    {
        const int minScore = 0;
        const int maxScore = 10;

        return ((score * samples) + minScore + maxScore) / (samples + 2);
    }
}