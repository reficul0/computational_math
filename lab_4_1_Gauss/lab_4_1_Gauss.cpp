#include <algorithm>
#include <iostream>
#include <vector>
#include <cassert>
#include <unordered_map>
#include <iomanip>
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

void ToTriangleMatrix(std::vector<std::vector<double>>& a, std::vector<double>& f)
{
    assert(a.size() == f.size());

    for (size_t k = 0; k < a.size() - 1; ++k)
    {
        // Метод Гаусса основан на идее последовательного исключения неизвестных. Введем n-1 множителей
        std::vector<double> m;
        m.reserve(a.size());
        // добавим фиктивный 1 элемент, чтобы упростить обращения через индекс
        for (size_t i = 0; i < a.size(); ++i)
        {
            if (i < (k + 1))
            {
                m.push_back(0);
            }
            else
            {
                double a_k_k = a[k][k];
                assert(a_k_k != 0);
                m.push_back(a[i][k] / a_k_k);
            }
        }

        // и вычтем из каждого i-го уравнения первое, домноженное на  m[i]
        for (size_t i = k + 1; i < a.size(); ++i)
        {
            double m_i = m[i];
            for (size_t j = k; j < a[i].size(); ++j)
            {
                a[i][j] -= m_i * a[k][j];
            }
            f[i] -= m_i * f[k];
        }

        // легко убедится в том, что для всех уравнений, начиная со второго
        for (size_t i = k + 1; i < a.size(); ++i)
        {
            assert(a[i][k] == 0);
        }
    }
}

std::vector<double> SolveTriangleMatrix(std::vector<std::vector<double>>& a, std::vector<double>& f)
{
    assert(a.size() == f.size());

    std::vector<double> x;
    x.resize(a.size());

    int64_t n = a.size()-1;
    assert(n != 0);
    
    for (int64_t k = n; k >= 0; k--)
    {
        double d = 0;
        for (int64_t j = k + 1; j <= n; j++)
        {
            d += a[k][j] * x[j];
        }
        x[k] = (f[k] - d) / a[k][k];
    }
    
    return x;
}

double GetDeterminantOfTriangleMatrix(std::vector<std::vector<double>>& a)
{
    double det = 1;
	for(size_t i = 0; i < a.size(); ++i)
	{
        det *= a.at(i).at(i);
	}
    return det;
}

int main()
{
    std::vector<std::vector<double>> a
	{
        { 2, 2, 3, 4, 5 },
        { 2, 5, 4, 5, 6 },
		{ 3, 4, 6, 6, 7 },
        { 4, 5, 6, 8, 8 },
        { 5, 6, 7, 8, 10 }
    };

    std::vector<double> f
	{
        16,
    	21,
        26,
        31,
        36
    };
    
    std::cout << "Source eq: " << std::endl;
    PrintLinearEq(a, f);

    ToTriangleMatrix(a, f);

	std::cout << std::endl << "Triangle eq: " << std::endl;
    PrintLinearEq(a, f);

    double det = GetDeterminantOfTriangleMatrix(a);
    std::cout << std::endl << "Determinant = " << det << std::endl;
    if(det == 0)
    {
        std::cout << "[ERROR] exit cause determinant is zero" << std::endl;
        return EXIT_FAILURE;
    }

    std::vector<double> solution = SolveTriangleMatrix(a, f);

    std::cout << std::endl << "Solution: " << std::endl;
    std::copy(solution.begin(), solution.end(), std::ostream_iterator<double>(std::cout, "\n"));

    std::cout << std::endl << "Test: " << std::endl;
    for(size_t i = 0; i<a.size(); ++i)
    {
        double equals = 0;
	    for(size_t j=0; j<a[i].size(); ++j)
	    {
            equals += a[i][j] * solution[j];
	    }
        
        std::string testResult = equals == f[i]
            ? std::string("[PASS]")
        	: std::string("[FAIL(") + std::to_string(std::abs(equals - f[i])) + ")]";

        std::cout << testResult << " calculated solution = " << equals << "; real = " << f[i] << std::endl;
    }

    std::cout << std::endl;
    return EXIT_SUCCESS;
}