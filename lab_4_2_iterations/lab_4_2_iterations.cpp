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

double Get1NormOfMatrix(std::vector<std::vector<double>>& a)
{
    double max = 0;
    for (size_t i = 0; i < a.size(); ++i)
    {
        double summ = 0.0;
        for (size_t j = 0; j < a[i].size(); ++j)
        {
            if (i == j)
                continue;
            summ += abs(a[i][j] / a[i][i]);
        }
        if (summ > max)
            max = summ;
    }
    return max;
}
double Get2NormOfMatrix(std::vector<std::vector<double>>& a)
{
    double max = 0;
    for (size_t i = 0; i < a.size(); ++i)
    {
        double summ = 0.0;
        for (size_t j = 0; j < a[i].size(); ++j)
        {
            if (i == j)
                continue;
            summ += abs(a[i][j] / a[j][j]);
        }
        if (summ > max)
            max = summ;
    }
    return max;
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

// If fromNext == true, then is Zeydel`s method 
// else is iteration`s method  
std::vector<double> NextIteration(
    std::vector<std::vector<double>>& a, std::vector<double>& f, std::vector<double>& x, bool fromNext)
{
    std::vector<double> xNext(x.size(), 0);

    for (size_t i = 0; i < a.size(); ++i)
    {
        double summ = 0;
        for (size_t j = 0; j < a[i].size(); ++j)
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
        { 32, 2,  1,   1,  3 },
        { 3,  32, 1,   1,  2 },
        { 1,  2,  56,  3,  3 },
        { 2,  3,  1,   56, 3 },
        { 1,  3,  2,   3,  16 }
    };

    std::vector<double> f
    {
        35,
        67,
        -45,
        172,
        -2
    };

    std::cout << "Source eq: " << std::endl;
    PrintLinearEq(a, f);
    
    double norm1 = Get1NormOfMatrix(a);
    double norm2 = Get2NormOfMatrix(a);
    if(norm1 >= 1 && norm2 >= 1)
    {
        if(norm1 >= 1)
			std::cout << "Can't solve cause ||a||1 = " << norm1 << ", that is >= 1" << std::endl;
        if (norm2 >= 1)
            std::cout << "Can't solve cause ||a||2 = " << norm2 << ", that is >= 1" << std::endl;
        return EXIT_FAILURE;
    }

    while (true)
    {
        double eps = 0;

        std::cout << "______________________________________________" << std::endl;
        std::cout << "Enter eps: ";
    	std::cin >> eps;
        std::cout << std::endl;

        std::cout << "Iterations:\n";
        SolveAndTest(a, f, eps, true);

        std::cout << "Zeydel:\n";
        SolveAndTest(a, f, eps, false);
    }
}