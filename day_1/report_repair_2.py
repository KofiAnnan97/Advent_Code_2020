from pprint import pprint
import os

#run in the directory of the file
parent_dir = os.getcwd()
file = os.path.join(parent_dir, "./data.txt")

target_num = 2020

def parse_clean(file):
    try:
        with open(file, 'r') as f:
            data = dict()
            lines = f.readlines()
            for l in lines:
                l = int(l)
                data[l] = target_num - l
            return data
    except OSError:
        print("File could not be found.")

def parse_vals_half_of_target_num(d):
    data = list()
    for l in d.keys():
        if l < target_num/2:
            data.append(l)
    return data

def parse_pairs(lst):
    int_dict = dict()
    for i in range(len(lst)):
        for j in range(len(lst)):
            if i != j:
                two_sum_num = lst[i] + lst[j]
                remaining = target_num - two_sum_num
                int_dict[two_sum_num] = (remaining, lst[i], lst[j])
    return int_dict

def main(argv=None):
    answers = dict()
    all_vals = parse_clean(file)
    int_lst = parse_vals_half_of_target_num(all_vals)
    int_dict = parse_pairs(int_lst)

    for num, num_lst in int_dict.items():
        try:
            expected_num = num_lst[0]
            if expected_num in all_vals.keys():
                multi = num_lst[0] * num_lst[1] * num_lst[2]
                if multi not in answers.keys():
                    answers[multi] = num_lst
        except KeyError:
            continue 
    print(answers)

if __name__ == '__main__':
    main()