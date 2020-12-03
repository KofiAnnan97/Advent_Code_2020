import os, re

#run in the directory of the file
parent_dir = os.getcwd()
data = os.path.join(parent_dir, "./data.txt")


def check_policy(policy):
    policy_lst = re.split(r'\s', policy)
    low_range = int(re.sub(r'-\d+', '', policy_lst[0]))
    high_range = int(re.sub(r'\d+-', '', policy_lst[0]))
    check_char = policy_lst[1][:-1]
    password = policy_lst[2]
    if check_char not in password:
        #print('f')
        return False
    else:
        count = 0
        for i in range(len(password)):
            if password[i] is check_char:
                count +=1
        return count >= low_range and count <= high_range


def parse_policies(file):
    count = 0
    with open(file, 'r') as f:
        policies = f.readlines()
        for policy in policies:
            if check_policy(policy):
                count+=1
    return count

def main(argv=None):
    count = parse_policies(data)
    print("Count: ", count)

if __name__ == '__main__':
    main()