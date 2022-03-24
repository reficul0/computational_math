#include <algorithm>
#include <iostream>
#include <vector>
#include <cassert>
#include <unordered_map>
#include <iomanip>
#include <numeric>
#include <string>
#include <stdlib.h>

void PrintLinearEq(std::vector<std::vector<double>>& a, std::vector<double>& f)
{
    assert(a.size() == f.size());

    for (size_t i = 0; i < a.size(); i++)
    {
        for (double element : a[i])
        {
            std::cout << std::setw(6) << std::left << std::setprecision(3) << element << " ";
        }
        std::cout << " | " << f[i] << std::endl;
    }
}

bool IsEpsilonAchieved(std::vector<double>& x, std::vector<double>& xNext, double eps)
{
    assert(eps > 0);
    assert(x.size() == xNext.size());
    
	for(size_t i = 0; i < x.size(); ++i)
	{
        bool isEpsilonAchieved = std::abs(x[i] - xNext[i]) <= eps;
        if(!isEpsilonAchieved)
        {
            return false;
        }
	}
    return true;
}

std::vector<double> NextIteration(
    std::vector<std::vector<double>>& a, std::vector<double>& f, std::vector<double>& x, bool fromNext)
{
    std::vector<double> xNext(x.size(), 0);

    for (size_t i = 0; i < a.size(); ++i)
    {
        double summ = 0;
        for (size_t j = 0; j < a.size(); ++j)
        {
            if (j == i)
            {
                continue;
            }

            auto xVal = (fromNext && j < i)
		                ? xNext[j]
		                : x[j];

            summ += a[i].at(j) / a[i][i] * xVal;
        }
        xNext[i] = f[i] / a[i].at(i) - summ;
    }

    return xNext;
}

std::vector<double> Solve(
    std::vector<std::vector<double>>& a, std::vector<double>& f, double eps, bool isIterations)
{
    assert(a.size() == f.size());

    size_t iterations = 0;

    std::vector<double> x;
    std::vector<double> xNext = f;
	do
	{
        x = xNext;
        xNext = NextIteration(a, f, x, !isIterations);
        ++iterations;
    }
	while (!IsEpsilonAchieved(x, xNext, eps));

    std::cout << "solved, iterations == " << iterations;

    return xNext;
}

void SolveAndTest(
    std::vector<std::vector<double>>& a, std::vector<double>& f, double eps, bool isIterations)
{
    std::vector<double> solution = Solve(a, f, eps, isIterations);

    std::cout << std::endl << "Solution: " << std::endl;
    std::cout.precision(10);
    std::copy(solution.begin(), solution.end(), std::ostream_iterator<double>(std::cout, "\n"));

    std::cout << std::endl << "Test: " << std::endl;
    for (size_t i = 0; i < a.size(); ++i)
    {
        double equals = 0;
        for (size_t j = 0; j < a[i].size(); ++j)
        {
            equals += a[i][j] * solution[j];
        }

        std::string testResult = equals == f[i]
            ? std::string("[PASS]")
            : std::string("[FAIL(") + std::to_string(std::abs(equals - f[i])) + ")]";

        std::cout << testResult << " calculated solution = " << equals << "; real = " << f[i] << std::endl;
    }

    std::cout << std::endl;
}

int main()
{
    std::vector<std::vector<double>> a
    {
        { 32, 2, 1, 3, 1 },
        { 1, 8, 3, 1, 3 },
        { 1, 2, 16, 3, 1 },
        { 1, 2, 3, 56, 1 },
        { 1, 2, 1, 3, 32 }
    };

    std::vector<double> f
    {
        43,
        14,
        -3,
        169,
        -19
    };

    std::cout << "Source eq: " << std::endl << std::endl;
    PrintLinearEq(a, f);

    //if(!CanSolveByIterations(a))
    //{
    //    return EXIT_FAILURE;
    //}

    while (true)
    {
        double eps = 0;
        bool isIterations = false;

        std::cout << "______________________________________________" << std::endl;
        std::cout << "Iterations? ";

        std::cin >> isIterations;
        std::cout << "Enter eps: ";
    	std::cin >> eps;
        std::cout << std::endl;

        SolveAndTest(a, f, eps, isIterations);
    }
}