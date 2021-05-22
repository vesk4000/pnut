#include <iostream>
#include <stdio.h>
#include <string.h>
using namespace std;
typedef long long llong;

const int MAX_N = 500000;
const llong MOD = 1000000007LL;

int n, k;
int vals[MAX_N + 111];

/**
0 - Same blockers on both sides
1 - Different blockers on two sides
2 - Blocker on one side
3 - No blockers
**/
llong F[MAX_N + 111][4];

llong computeF(int sz, int boundType)
{
    if (sz == 0)
        return 1LL;
    if (sz == 1)
    {
        if (boundType == 0 || boundType == 2)
            return k - 1;
        else if (boundType == 1)
            return k - 2;
        else
            return k;
    }
    if (F[sz][boundType] != -1)
        return F[sz][boundType];

    if (boundType == 0)
        return 0;

    if (boundType == 0)
        F[sz][boundType] = (llong)(k - 1) * computeF(sz - 1, 1);
    else if (boundType == 1)
        F[sz][boundType] = (llong)(k - 2) * computeF(sz - 1, 1) + computeF(sz - 1, 0);
    else if (boundType == 2)
        F[sz][boundType] = (llong)(k - 1) * computeF(sz - 1, 2);
    else
        F[sz][boundType] = (llong)k * computeF(sz - 1, 2);

    F[sz][boundType] %= MOD;

    return F[sz][boundType];
}

int main()
{
    int i, j;

    memset(F, -1, sizeof(F));

    scanf("%d %d", &n, &k);

    for (i=1;i<=n;i++)
    {
        scanf("%d", &vals[i]);
    }

    llong ans = 1;
    int lastVal = 0;
    vals[n+1] = -1;
    for (i=1;i<=n+1;i++)
    {
        if (vals[i] != 0)
        {
            int len = i - lastVal - 1;
            if (lastVal == 0 && i == n + 1)
                ans *= computeF(len, 3);
            else if (lastVal == 0 || i == n + 1)
                ans *= computeF(len, 2);
            else if (vals[i] != vals[lastVal])
                ans *= computeF(len, 1);
            else
                ans *= computeF(len, 0);

            ans %= MOD;
            lastVal = i;
        }
    }

    printf("%lld\n", ans);

    return 0;
}
