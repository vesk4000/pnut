#include <iostream>
#include <stdio.h>
#include <string.h>
using namespace std;
typedef long long llong;

const llong MOD = 1000000007LL;

int n, k;

int main()
{
    int i, j, in;
    llong ans = 1LL;

    scanf("%d %d", &n, &k);

    ans = k;
    for (i=1;i<n;i++)
    {
        ans *= (llong)(k - 1);
        ans %= MOD;
    }

    printf("%lld\n", ans);

    return 0;
}
