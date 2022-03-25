#include <functional>
#include <math.h> 
#include <iostream>
#include <map>
#include <iomanip>
#include <stdlib.h>
#include <vector>

void metodRK(
    double x,
    double xLast,
    double y,
    double step,
    std::function<double(double, double)> func,
    std::map<double, double>& x_yContainer)
{
    int n = static_cast<int>((xLast - x) / step);
    x_yContainer[x] = y;
    for (int i = 0; i < n; i++)
    {
        bool isPointExist = true;
        try
        {
            double k1 = step * func(x, y);
            double k2 = step * func(x + step / 2.0, y + k1 / 2.0);
            double k3 = step * func(x + step / 2.0, y + k2 / 2.0);
            double k4 = step * func(x + step, y + k3);

            y += (k1 + 2 * k2 + 2 * k3 + k4) / 6.0;
        }
        catch (const std::runtime_error&)
        {
            isPointExist = false;
        }

        x += step;
        if (isPointExist)
        {
            x_yContainer[x] = y;
        }
    }
}

int main()
{
    auto func = [](double x, double z)
    {
        return (-x)*z;
    };
	auto func2 = [](double x, double y)
    {
        if (x == .0)
            throw std::runtime_error("x == 0 isn't exists");

        return y/x;
    };

    double step = .1;
    double xFirst = 0;
    double xLast = 1;
    double zFirst = 1;
    double yFirst = 0;

    std::map<double, double> x_zContainer;
    {

	    metodRK(xFirst, xLast, zFirst, step, func, x_zContainer);

	    std::cout << std::setprecision(10);
	    for (std::pair<const double, double> const& x_y : x_zContainer)
	    {
	        std::cout << "x =  " << x_y.first << " : " << ",  y =  " << x_y.second << std::endl;
	    }
    }

    std::map<double, double> x_yContainer;
    {
        metodRK(xFirst, xLast, yFirst, step, func2, x_yContainer);
        for (std::pair<const double, double> const& x_y : x_yContainer)
        {
            std::cout << "x =  " << x_y.first << " : " << ",  y =  " << x_y.second << std::endl;
        }
    }

    std::vector<std::tuple<double, double, double>> x_y_z;
    for(std::pair<const double, double>& x_z : x_zContainer)
    {
        auto x_yIter = x_yContainer.find(x_z.first);
	    if(x_yIter != x_yContainer.end())
	    {
            x_y_z.push_back(std::make_tuple(x_z.first, x_yIter->second, x_z.second));
	    }
    }


    std::cout << "solution { y' = -x*z; z' = y/x }"
				<< " x from " << xFirst << " to " << xLast
				<< " y(0) = " << yFirst
				<< " z(0) = " << zFirst;
    for (auto const& x_y_z : x_y_z)
    {
        double x, y, z;
        std::tie(x, y, z) = x_y_z;

        std::cout << std::endl << "x =  " << x << ",  y =  " << y << ", z =" << z << std::endl;
    }

    std::cout << "========================================================================" << std::endl;

    return 0;
}