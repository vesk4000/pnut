#include <bits/stdc++.h>
using namespace std;

int n;
const int MAXN = 5 * 1e5;
long long int k;
//const long long int MAXK = 10e9;
long long int rock[MAXN];
//int pos[2][MAXK]; /// possibilities
const long long int MOD = 1e9 + 7;

int main() {
    cin >> n >> k;
    for(int i = 0; i < n; ++i) {
        cin >> rock[i];
        //cout << rock[i] << endl;
    }

    unsigned long long int special = 0;
    long long int special_index = -1;
    unsigned long long int others = 1;

    if(rock[0] != 0) { /// if the first rock is already colored
        special = 1;
        special_index = rock[0];
        others = 0;
    }

    for(int i = 1; i < n; ++i) {
        if(rock[i] != 0) { /// if the current rock is colored
            if(special_index == -1 || special_index == rock[i]) /// if we don't have a special number or its the same special number
                special = others * (k - 1) % MOD;
            else
                special = (others * (k - 2)) % MOD + special % MOD;
            special_index = rock[i];
            others = 0;
        }
        else { /// the current rock isn't colored
            //cout << "not colored " << special_index << endl;
            if(special_index == -1) /// if we don't have a special number
                others = others * (k - 1) % MOD;
            else { /// we have a special number
                //cout << "special" << endl;
                unsigned long long int old_special = special;
                unsigned long long int old_others = others;
                special = old_others * (k - 1) % MOD;
                others = (old_others * (k - 2)) % MOD + old_special % MOD;
            }
        }
        //cout << special_index << " " << special << " " << others << endl;
    }

    long long int ans;
    if(special_index == -1) /// if we don't have a special number
        ans = others * k % MOD;
    else
        ans = (others * (k - 1) + special) % MOD;

    cout << ans << endl;

    return 0;
}
