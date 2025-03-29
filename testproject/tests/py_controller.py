# main_controller.py
import subprocess
import re
import statistics

child_input = input("Enter the child's proposed resolution method: ")

scores = {
    "A": [],
    "B": [],
    "C": [],
    "D": []
}

print("\n📊 Running analysis 5 times...\n")

for i in range(1):
    print(f"▶ Run {i+1}")
    result = subprocess.run(
        ["python", "main_3.py", child_input],
        stdout=subprocess.PIPE,
        stderr=subprocess.PIPE,
        encoding='utf-8'
    )

    output = result.stdout.strip()
    print("Result:", output)

    match = re.match(r"\[A:\s*([\d.]+)%,\s*B:\s*([\d.]+)%,\s*C:\s*([\d.]+)%,\s*D:\s*([\d.]+)%\]", output)
    if match:
        scores["A"].append(float(match.group(1)))
        scores["B"].append(float(match.group(2)))
        scores["C"].append(float(match.group(3)))
        scores["D"].append(float(match.group(4)))
    else:
        print("❌ Failed to parse:", output)

# 평균 계산
average_scores = {
    k: round(statistics.mean(v), 1) if v else 0.0 for k, v in scores.items()
}

print("\n✅ Final Average Similarity Scores:")
print(f"[A: {average_scores['A']}%, B: {average_scores['B']}%, C: {average_scores['C']}%, D: {average_scores['D']}%]")
