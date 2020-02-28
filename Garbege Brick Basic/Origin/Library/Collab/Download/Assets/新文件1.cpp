#include<iostream>
using namespace std;

int main() {
	string s, ss, fs;
	ss = "string fname = {";
	fs = "float inv_time = {";
	bool sst = false, fst = false;
	while (getline(cin, s))
	{
		if(s == "0")
			break;
		for (int i=0; i<s.size(); i++)
		{
			if (s[i] == '"')
			{
				int j;
				for (j=i+1; s[j]!='"'; j++);
				if (sst)
				{
					ss += ", ";
				}
				sst = true;
				ss += s.substr(i, j-i+1);
				i = j;
			}
			else if (s[i] == ',')
			{
				int j;
				for (j=i+1; s[j]==' '; j++);
				i = j;
				for (j=i+1; s[j]!='f'; j++);
				if (fst)
				{
					fs += ", ";
				}
				fst = true;
				fs += s.substr(i, j-i+1);
				break;
			}
		}
	}
	ss += "};";
	fs += "};";
	freopen("D:\\out.txt", "w", stdout);
	cout<<"Done"<<endl;
	cout << ss << '\n';
	cout << fs << '\n';

	return 0;
}

