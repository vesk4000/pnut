#include <iostream>
#include <stdio.h>
#include <string.h>
using namespace std;
typedef long long llong;

const int MAX_N = 100000;
const llong MOD = 1000000007LL;

int n, k;
int vals[MAX_N + 111];
llong ans = 0LL;

int filled[MAX_N + 111];

void batrak(int ind)
{
    if (ind > n)
    {
        ans++;
        return;
    }

    int i;

    if (vals[ind] != 0)
    {
        if (ind != 1 && vals[ind] == filled[ind-1])
            return;

        filled[ind] = vals[ind];
        batrak(ind + 1);
    }
    else
    {
        for (i=1;i<=k;i++)
        {
            if (vals[ind] != 0 && vals[ind] != i)
                continue;

            filled[ind] = i;

            if (ind == 1 || filled[ind] != filled[ind - 1])
                batrak(ind + 1);
        }
    }
}

int main()
{
    int i, j, in;

    scanf("%d %d", &n, &k);

    for (i=1;i<=n;i++)
    {
        scanf("%d", &vals[i]);
    }

    batrak(1);

    printf("%lld\n", ans);

    return 0;
}
