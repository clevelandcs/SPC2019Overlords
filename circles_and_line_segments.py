import math

def is_valid_line_segment_range(value):
    return value >= -100 and value <= 100

def main():
    num_line_segments = int(input())
    if num_line_segments >= 1 and num_line_segments <=16:
        line_segments = []
        for _ in range(0, num_line_segments):
            line_segment_line = raw_input()
            line_segment_split_array = line_segment_line.split(' ')
            x1 = int(line_segment_split_array[0])
            y1 = int(line_segment_split_array[1])
            x2 = int(line_segment_split_array[2])
            y2 = int(line_segment_split_array[3])
            if is_valid_line_segment_range(x1) and is_valid_line_segment_range(x2) and is_valid_line_segment_range(y1) and is_valid_line_segment_range(y2):
                line_segments.append((x1, y1, x2, y2))
        
        center_line = raw_input()
        center_line_split_array = center_line.split(' ')
        center_x = int(center_line_split_array[0])
        center_y = int(center_line_split_array[1])

        radius = int(input())

        intersections = []
        for line_segment in line_segments:
            dx = line_segment[2] - line_segment[0]
            dy = line_segment[3] - line_segment[1]

            a = dx * dx + dy * dy
            b = 2 * (dx * (line_segment[0] - center_x) + dy * (line_segment[1] - center_y))
            c = (line_segment[0] - center_x) * (line_segment[0] - center_x) + (line_segment[1] - center_y) * (line_segment[1] - center_y) - radius * radius

            print(a)
            print(b)
            print(c)
            print()
            det = b * b - 4 * a * c
            if det == 0:
                t = -b / (2 * a)
                intersection_x = round(line_segment[0] + t * dx, 3)
                intersection_y = round(line_segment[1] + t * dy, 3)
                intersections.append((intersection_x, intersection_y))
            elif det > 0:
                print("Two Solutions Hit")
                print("Line Segment: {} {} {} {}", line_segment[0], line_segment[1], line_segment[2], line_segment[3])
                t1 = (-b + math.sqrt(det)) / (2 * a)
                t2 = (-b - math.sqrt(det)) / (2 * a)
                intersection_x_1 = round(line_segment[0] + t1 * dx, 3)
                intersection_y_1 = round(line_segment[1] + t1 * dy, 3)
                intersection_x_2 = round(line_segment[0] + t2 * dx, 3)
                intersection_y_2 = round(line_segment[1] + t2 * dy, 3)

                intersections.append((intersection_x_1, intersection_y_1))
                intersections.append((intersection_x_2, intersection_y_2))
        
        sorted_intersections = sorted(intersections, key = lambda x: (x[0], x[1]))
        for intersection in sorted_intersections:
            print("{} {}".format('%.3f' % intersection[0], '%.3f' % intersection[1]))


main()