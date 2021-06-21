#include <bits/stdc++.h>
#include <Windows.h>
using namespace std;

int take_time() {
	int sum = 0;
	for(int i = 0; i < 1000000000; ++i) {
		sum += i;
		sum %= 10000;
	}
	return sum;
}

int arr[100000000];

int main() {
	int n;
	cin >> n;
	memset(arr, 1, sizeof(arr));
	for(int i = 0; i < n; ++i) {
		int a, b;
		cin >> a >> b;
		cout << a * b << endl;
		cout << arr[5] << endl;
		//cout << take_time() << endl;
	}
	return 0;
}