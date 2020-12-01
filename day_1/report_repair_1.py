
target_num = 2020

def parse_data(file):
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

def main(argv=None):
	file = "/Users/c284181/Documents/Scripts/advent_code_2020/day_1/data.txt" 
	answers = dict()
	int_dict = parse_data(file)
	for num, expected_num in int_dict.items():
		try:
			if expected_num in int_dict.keys() and num == int_dict[expected_num]:
				multi = num * expected_num
				if multi not in answers.keys():
					answers[multi] = (num, expected_num)
		except KeyError:
			continue 
	print(answers)

if __name__ == '__main__':
    main()