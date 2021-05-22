#include <iostream>
#include <stdio.h>
#include <string.h>
using namespace std;
typedef long long llong;

const int MAX_N = 3000;
const int MAX_K = 3000;
const llong MOD = 1000000007LL;

int n, k;
int vals[MAX_N + 111];
llong F[MAX_N + 111][MAX_K + 111];

int main()
{
    int i, j, in;

    scanf("%d %d", &n, &k);

    for (i=1;i<=n;i++)
    {
        scanf("%d", &vals[i]);
    }

    for (i=1;i<=k;i++)
    {
        if (vals[1] != 0 && vals[1] != i)
            continue;

        F[1][i] = 1;
    }

    for (i=2;i<=n;i++)
    {
        for (j=1;j<=k;j++)
        {
            if (vals[i] != 0 && vals[i] != j)
                continue;

            for (in=1;in<=k;in++)
            {
                if (in != j)
                {
                    F[i][j] += F[i-1][in];
                    if (F[i][j] >= MOD)
                        F[i][j] -= MOD;
                }
            }
        }
    }

    llong ans = 0;
    for (i=1;i<=k;i++)
    {
        ans += F[n][i];
    }
    ans %= MOD;

    printf("%lld\n", ans);

    return 0;
}
