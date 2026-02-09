"""
Lab 3: Iteration, file handling, error handling, and dictionaries
Author: [Your Name]
Date: [Current Date]
"""

# ====================== Task 1: Insertion Sort ======================

def insert_in_sorted(x, sorted_list):
    """
    Insert an element x into a sorted list in the correct position.
    
    Parameters:
    x: element to insert
    sorted_list: list that is already sorted (ascending order)
    
    Returns:
    New sorted list with x inserted
    """
    # Create a new list to avoid modifying the original
    result = []
    inserted = False
    
    # Iterate through the sorted list
    for element in sorted_list:
        # If we haven't inserted x yet and x is smaller than or equal to current element
        if not inserted and x <= element:
            result.append(x)
            inserted = True
        result.append(element)
    
    # If x wasn't inserted (it's larger than all elements), add it at the end
    if not inserted:
        result.append(x)
    
    return result


def insertion_sort(my_list):
    """
    Sort a list using the insertion sort algorithm.
    
    Parameters:
    my_list: list to sort
    
    Returns:
    New sorted list
    """
    # Start with an empty sorted list
    out = []
    
    # Insert each element from my_list into the sorted list
    for element in my_list:
        out = insert_in_sorted(element, out)
    
    return out


# ====================== Task 2: File Handling ======================

def number_lines(f):
    """
    Create a new file with the same contents as f, but with line numbers.
    
    Parameters:
    f: filename to process
    """
    # Create the output filename
    output_filename = "numbered_" + f
    
    try:
        # Open the input file for reading
        with open(f, 'r', encoding='utf-8') as input_file:
            lines = input_file.readlines()
        
        # Open the output file for writing
        with open(output_filename, 'w', encoding='utf-8') as output_file:
            # Write each line with its line number
            for i, line in enumerate(lines):
                # Remove trailing newline to avoid double newlines
                line = line.rstrip('\n')
                output_file.write(f"{i} {line}\n")
                
    except FileNotFoundError:
        print(f"Error: File '{f}' not found.")
    except Exception as e:
        print(f"Error processing file: {e}")


# ====================== Task 3: Simple Text Indexing ======================

def index_text(filename):
    """
    Create an index of words in a text file with their line numbers.
    
    Parameters:
    filename: name of the text file
    
    Returns:
    Dictionary where keys are words and values are lists of line numbers
    """
    index_table = {}
    
    try:
        with open(filename, 'r', encoding='utf-8') as file:
            lines = file.readlines()
            
            # Process each line
            for line_num, line in enumerate(lines):
                # Convert to lowercase and split into words
                words = line.lower().strip().split()
                
                # For each word in the line
                for word in words:
                    # Remove any remaining punctuation (though not strictly needed per spec)
                    word = ''.join(char for char in word if char.isalpha())
                    if not word:  # Skip empty words
                        continue
                    
                    # If word is already in index
                    if word in index_table:
                        # Add line number if not already present
                        if line_num not in index_table[word]:
                            index_table[word].append(line_num)
                    else:
                        # Create new entry with current line number
                        index_table[word] = [line_num]
                        
    except FileNotFoundError:
        # Return None to indicate file not found (handled in main program)
        return None
    except Exception as e:
        print(f"Error reading file '{filename}': {e}")
        return None
    
    return index_table


def important_words(an_index, stop_words):
    """
    Find the five most frequent words in an index, ignoring stop words.
    
    Parameters:
    an_index: dictionary from index_text() function
    stop_words: list of words to ignore
    
    Returns:
    List of up to 5 most frequent words
    """
    # If index is None or empty, return empty list
    if an_index is None or not an_index:
        return []
    
    # Filter out stop words and convert to lowercase for comparison
    stop_words_lower = [word.lower() for word in stop_words]
    
    # Create a list of (word, frequency) tuples, excluding stop words
    word_frequencies = []
    for word, line_numbers in an_index.items():
        if word.lower() not in stop_words_lower:
            # Frequency is number of lines the word appears on
            frequency = len(line_numbers)
            word_frequencies.append((word, frequency))
    
    # If there are no words after filtering stop words
    if not word_frequencies:
        return []
    
    # Use a simple bubble-sort-like approach to find top 5 (since we can't use sort/sorted)
    # We'll find the maximum frequency words one by one
    top_words = []
    
    # We need at most 5 words, but no more than available
    num_to_select = min(5, len(word_frequencies))
    
    for _ in range(num_to_select):
        if not word_frequencies:
            break
            
        # Find the word with maximum frequency
        max_freq_index = 0
        max_freq = word_frequencies[0][1]
        
        for i in range(1, len(word_frequencies)):
            if word_frequencies[i][1] > max_freq:
                max_freq = word_frequencies[i][1]
                max_freq_index = i
        
        # Add the word with maximum frequency to results
        top_words.append(word_frequencies[max_freq_index][0])
        
        # Remove it from the list so we can find the next maximum
        word_frequencies.pop(max_freq_index)
    
    return top_words


def main():
    """
    Main program for Task 3c: Prompt user for a text file and display most important words.
    """
    # Define stop words for Swedish
    stop_words = ['och', 'jag', 'som', 'det', 'för']
    
    while True:
        # Get filename from user
        filename = input("Enter a text file: ").strip()
        
        if not filename:
            print("No filename entered. Please try again.")
            continue
        
        # Create index
        index = index_text(filename)
        
        # Check if index creation failed (file not found or other error)
        if index is None:
            print(f"File '{filename}' not found or could not be read. Please try again.")
            continue
        
        # Get important words
        important = important_words(index, stop_words)
        
        # Display results
        if important:
            print("The most important words are:")
            for word in important:
                print(word)
        else:
            print("No important words found (or all words were stop words).")
        
        # Ask if user wants to try another file
        another = input("Would you like to analyze another file? (y/n): ").strip().lower()
        if another != 'y':
            break


# ====================== Test Code ======================

if __name__ == "__main__":
    # Test Task 1
    print("Testing Task 1: Insertion Sort")
    print("Testing insert_in_sorted:")
    print(f"insert_in_sorted(2, []) = {insert_in_sorted(2, [])}")
    print(f"insert_in_sorted(5, [0, 1, 3, 4]) = {insert_in_sorted(5, [0, 1, 3, 4])}")
    print(f"insert_in_sorted(2, [0, 1, 2, 3, 4]) = {insert_in_sorted(2, [0, 1, 2, 3, 4])}")
    print(f"insert_in_sorted(2, [2, 2]) = {insert_in_sorted(2, [2, 2])}")
    
    print("\nTesting insertion_sort:")
    print(f"insertion_sort([12, 4, 3, -1]) = {insertion_sort([12, 4, 3, -1])}")
    print(f"insertion_sort([]) = {insertion_sort([])}")
    
    # Test Task 2 - Create a test file first
    print("\nTesting Task 2: File Handling")
    # Create a test poem file
    test_poem = """A Dead Statesman

I could not dig; I dared not rob:
Therefore I lied to please the mob.
Now all my lies are proved untrue
And I must face the men I slew.
What tale shall serve me here among
Mine angry and defrauded young?"""
    
    with open('poem.txt', 'w', encoding='utf-8') as f:
        f.write(test_poem)
    
    print("Creating numbered version of 'poem.txt'...")
    number_lines('poem.txt')
    
    # Read and display the numbered file
    try:
        with open('numbered_poem.txt', 'r', encoding='utf-8') as f:
            print("\nContents of numbered_poem.txt:")
            print(f.read())
    except FileNotFoundError:
        print("Could not find numbered_poem.txt")
    
    # Test Task 3 with a sample file
    print("\n" + "="*50)
    print("Testing Task 3: Text Indexing")
    
    # Create a simple test file
    test_content = """Sommar och sol
Sol och vatten"""
    
    with open('sommar.txt', 'w', encoding='utf-8') as f:
        f.write(test_content)
    
    # Test index_text
    print("\nTesting index_text on 'sommar.txt':")
    index = index_text('sommar.txt')
    print(f"Index: {index}")
    
    # Test important_words
    print("\nTesting important_words:")
    important = important_words(index, ['and'])  # 'and' is not in the text
    print(f"Important words (excluding 'and'): {important}")
    
    # Test with stop words that are in the text
    print("\nTesting important_words with Swedish stop words:")
    important = important_words(index, ['och'])  # 'och' is in the text
    print(f"Important words (excluding 'och'): {important}")
    
    print("\n" + "="*50)
    print("Now testing the main program. You can enter 'sommar.txt' to test.")
    print("Or create your own text file and enter its name.")
    print("To exit, enter 'n' when asked if you want to analyze another file.")
    print("="*50 + "\n")
    
    # Run the main program
    main()