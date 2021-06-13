import sys
import os

if len(sys.argv) != 2:
    print('Wrong number of arguments')
    exit(0)


PROGRAM = sys.argv[1]
for test in range(1, 51):
    print('Solving test', test)
    
    inpf = 'colors.' + str(test // 10) + str(test % 10) + '.in'
    outf = 'colors.' + str(test // 10) + str(test % 10) + '.sol'
    pcall = PROGRAM + " <" + inpf + " >" + outf
    os.system(pcall)
    