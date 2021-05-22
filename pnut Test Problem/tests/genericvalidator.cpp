#include <bits/stdc++.h>
#include <vector>
#include <set>
#include <map>
#include <string>
#include <cstdio>
#include <cstdlib>
#include <climits>
#include <utility>
#include <algorithm>
#include <cmath>
#include <queue>
#include <stack>
#include <iomanip>
//setbase - cout << setbase (16); cout << 100 << endl; Prints 64
//setfill -   cout << setfill ('x') << setw (5); cout << 77 << endl; prints xxx77
//setprecision - cout << setprecision (14) << f << endl; Prints x.xxxx
//cout.precision(x)  cout<<fixed<<val;  // prints x digits after decimal in val

using namespace std;
#define f(i,a,b) for(i=a;i<b;i++)
#define rep(i,n) f(i,0,n)
#define fd(i,a,b) for(i=a;i>=b;i--)
#define pb push_back
#define mp make_pair
#define vi vector< int >
#define vl vector< ll >
#define ss second
#define ff first
#define ll long long
#define pii pair< int,int >
#define pll pair< ll,ll >
#define sz(a) a.size()
#define inf (1000*1000*1000+5)
#define all(a) a.begin(),a.end()
#define tri pair<int,pii>
#define vii vector<pii>
#define vll vector<pll>
#define viii vector<tri>
#define mod (1000*1000*1000+7)
#define pqueue priority_queue< int >
#define pdqueue priority_queue< int,vi ,greater< int > >
typedef long long llong;

const int MaxN = (int)1e5 + 10;
const int MOD = (int)1e9 + 7;
const int INF = 1e9;

long long readInt(long long l,long long r,char endd){
	long long x=0;
	int cnt=0;
	int fi=-1;
	bool is_neg=false;
	while(true){
		char g=getchar();
		if(g=='-'){
			assert(fi==-1);
			is_neg=true;
			continue;
		}
		if('0'<=g && g<='9'){
			x*=10;
			x+=g-'0';
			if(cnt==0){
				fi=g-'0';
			}
			cnt++;
			assert(fi!=0 || cnt==1);
			assert(fi!=0 || is_neg==false);

			assert(!(cnt>19 || ( cnt==19 && fi>1) ));
		} else if(g==endd){
			if(is_neg){
				x= -x;
			}
			assert(l<=x && x<=r);
			return x;
		} else {
			assert(false);
		}
	}
}
string readString(int l,int r,char endd){
	string ret="";
	int cnt=0;
	while(true){
		char g=getchar();
		assert(g!=-1);
		if(g==endd){
			break;
		}
		cnt++;
		ret+=g;
	}
	assert(l<=cnt && cnt<=r);
	return ret;
}
long long readIntSp(long long l,long long r){
	return readInt(l,r,' ');
}
long long readIntLn(long long l,long long r){
	return readInt(l,r,'\n');
}
string readStringLn(int l,int r){
	return readString(l,r,'\n');
}
string readStringSp(int l,int r){
	return readString(l,r,' ');
}

void ASSERT(bool s, string msg)
{
    if (!s)
    {
        cout<<msg<<endl;
        while(1);
    }
}

string toStr(int num)
{
    if (num == 0)
        return "00";

    string s;

    while(num > 0)
    {
        s.push_back(num%10 + '0');
        num /= 10;
    }

    reverse(s.begin(), s.end());

    if (s.length() == 1)
        s = "0" + s;

    return s;
}

int fromStr(const char* s)
{
    int i;
    int ln = strlen(s);
    int num = 0;

    for (i=0;i<ln;i++)
    {
        num *= 10;
        num += s[i] - '0';
    }

    return num;
}

int TEST;
string TEST_FILE;
int SUBTASK;

int whichSubtask()
{
    return (TEST - 1) / 10 + 1;
}

void decodeTest(const char* td)
{
    TEST = fromStr(td);
    TEST_FILE = "colors." + toStr(TEST) + ".in";
    SUBTASK = whichSubtask();
}

int father[100111];

int Find(int ver)
{
    if (father[ver] == 0)
        return ver;
    else
    {
        father[ver] = Find(father[ver]);
        return father[ver];
    }
}

int main(int argc, char **argv)
{
    if (argc > 2)
    {
        fprintf(stderr, "Wrong number of arguments\n");
        return 0;
    }
    if (argc == 2)
        decodeTest(argv[1]);
    else
    {
        string DEF = "23";
        decodeTest(DEF.c_str());
    }

    freopen(TEST_FILE.c_str(),"r",stdin);
    std::ios::sync_with_stdio(false);
    printf("TEST %d SUBTASK %d [%s]\n", TEST, SUBTASK, TEST_FILE.c_str());

    llong MAXN = 500000, MAXK = 1000000000;

    if (SUBTASK == 1)
    {
        MAXN = 7;
        MAXK = 7;
    }
    else if (SUBTASK == 2 || SUBTASK == 3)
    {
        MAXN = 200;
        MAXK = 200;
    }
    else if (SUBTASK == 4)
    {
        MAXN = 3000;
        MAXK = 3000;
    }

    llong n, k;

    n = readIntSp(1, MAXN);
    k = readIntLn(3, MAXK);

    int lastV = -1;
    for (int i = 1; i <= n; i++)
    {
        llong x;

        int MAXREAD = k;
        if (SUBTASK == 2)
            MAXREAD = 0;

        if (i == n)
            x = readIntLn(0, MAXREAD);
        else
            x = readIntSp(0, MAXREAD);

        assert(x == 0 || x != lastV);
    }

    assert (getchar() == EOF);

    printf("OKAY %lld\n", n);

    return 0;
}
