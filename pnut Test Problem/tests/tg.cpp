#include <iostream>
#include <stdio.h>
#include <random>
#include <vector>
using namespace std;

mt19937 mt(1337);

int mtlr(int L, int R)
{
    return mt() % (R - L + 1) + L;
}

vector<int> randomDistribute(int n, int k, int cnt)
{
    int i;
    vector<int> res;

    for (i=1;i<=n;i++)
    {
        res.push_back(0);
    }

    int ctr = 0;
    while(ctr < cnt)
    {
        int ind = mt() % n;
        int col = mt() % k + 1;

        if (res[ind] != 0)
            continue;
        if (ind != 0 && res[ind - 1] == col)
            continue;
        if (ind != n - 1 && res[ind + 1] == col)
            continue;

        res[ind] = col;
        ctr++;
    }

    return res;
}

vector<int> chunkDistribute(int n, int k, int cnt)
{
    int i;
    vector<int> res;

    for (i=1;i<=n;i++)
    {
        res.push_back(0);
    }

    int indStart = mt() % (n - cnt + 1);

    res[indStart] = mt() % k + 1;
    for (i=indStart+1;i<=indStart+cnt-1;i++)
    {
        res[i] = mt() % k + 1;
        while(res[i] == res[i-1])
            res[i] = mt() % k + 1;
    }

    return res;
}

int n, k;
vector<int> vals;

int main()
{
    int test;
    int i;

    for (test=1;test<=50;test++)
    {
        printf("Test #%d\n", test);

        string fileName = "colors.";
        fileName.push_back(test/10 + '0');
        fileName.push_back(test%10 + '0');
        fileName += ".in";
        FILE *f = fopen(fileName.c_str(), "w");

        if (test <= 10)
        {
            if (test == 1)
            {
                n = 1;
                k = mtlr(3, 7);
                vals = randomDistribute(n, k, 0);
            }
            else if (test <= 8)
            {
                n = mtlr(2, 7);
                k = mtlr(3, 7);
                vals = randomDistribute(n, k, mtlr(0, n));
            }
            else
            {
                n = mtlr(2, 7);
                k = mtlr(3, 7);
                vals = randomDistribute(n, k, mtlr(0, 1));
            }
        }
        else if (test <= 20)
        {
            n = mtlr(100, 200);
            k = mtlr(100, 200);

            if (test >= 19)
            {
                n = 200;
                k = mtlr(190, 200);
            }

            vals = randomDistribute(n, k, 0);
        }
        else if (test <= 30)
        {
            n = mtlr(100, 200);
            k = mtlr(100, 200);

            if (test >= 29)
            {
                n = 200;
                k = mtlr(190, 200);
            }

            vals = randomDistribute(n, k, mtlr(0, n));

            if (test % 5 == 0)
                vals = chunkDistribute(n, k, mtlr(n / 4, n / 2));
        }
        else if (test <= 40)
        {
            n = mtlr(1500, 3000);
            k = mtlr(1000, 3000);

            if (test >= 38)
            {
                n = mtlr(2900, 3000);
            }

            vals = randomDistribute(n, k, mtlr(0, n));

            if (test % 5 == 0)
                vals = chunkDistribute(n, k, mtlr(n / 4, n / 2));
        }
        else
        {
            n = mtlr(300000, 500000);
            k = mtlr(100000000, 1000000000);

            if (test >= 48)
            {
                n = mtlr(450000, 500000);
                k = mtlr(900000000, 1000000000);
            }

            vals = randomDistribute(n, k, mtlr(0, n));

            if (test % 3 == 0)
                vals = randomDistribute(n, k, mtlr(0, 20));

            if (test % 5 == 0)
                vals = chunkDistribute(n, k, mtlr(n / 4, n / 2));
        }

        fprintf(f, "%d %d\n", n, k);

        for (i=0;i<n;i++)
        {
            fprintf(f, "%d", vals[i]);

            if (i != n - 1)
                fprintf(f, " ");
        }
        fprintf(f, "\n");
    }

    return 0;
}
