import re

def main():
    number_of_relations = int(input())
    relation_string = raw_input()
    relation_match_obj = re.match(r'My (.*) told me', relation_string)
    relation_line = relation_match_obj.group(1)
    relation_line_split_array = relation_line.split(' ')
    
    relation_line_list = []

    possessive_jobs = re.findall(r"([^']+)'s\s*", relation_line)
    for job in possessive_jobs:
        relation_line_list.append(job)
    
    relation_line_list.append(relation_line_split_array[len(relation_line_split_array) - 1])

    name_relation_dictionary = {}
    for _ in range(0, number_of_relations):
        name_relation_string = raw_input()
        if "'" in name_relation_string:
            name_relation_split_array = name_relation_string.split("'")
        
            name = name_relation_split_array[0]
            name_match_obj = re.match(r's? (.*) is (.*)', name_relation_split_array[1])
            name_relation_dictionary[(name, name_match_obj.group(1))] = name_match_obj.group(2)
        else:
            name_match_obj = re.match(r'(.*) (.*) is (.*)', name_relation_string)
            name_relation_dictionary[("My", name_match_obj.group(2))] = name_match_obj.group(3)
    
    current_name = "My"
    for relation in relation_line_list:
        current_name = name_relation_dictionary[(current_name, relation)]
    
    print(current_name)
    
    
main()