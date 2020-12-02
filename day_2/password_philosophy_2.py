import os, re

parent_dir = os.getcwd()
data = os.path.join(parent_dir, "day_2/data.txt")


def check_policy(policy):
    policy_lst = re.split('\s', policy)
    low_range = int(re.sub('-\d+', '', policy_lst[0]))
    high_range = int(re.sub('\d+-', '', policy_lst[0]))
    check_char = policy_lst[1][:-1]
    password = policy_lst[2]
    try:
        char_1 = password[low_range-1]
        char_2 = password[high_range-1]
        return (char_1 is check_char or char_2 is check_char) and (char_1 != char_2)
    except:
        return False

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
    print("Count: ", count) #Count = 404

if __name__ == '__main__':
    main()