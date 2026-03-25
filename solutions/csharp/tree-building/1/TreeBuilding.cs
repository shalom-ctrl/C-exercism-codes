using System;
using System.Collections.Generic;
using System.Linq;

public class TreeBuildingRecord
{
    public int ParentId { get; set; }
    public int RecordId { get; set; }
}

public class Tree
{
    public int Id { get; set; }
    public int ParentId { get; set; }
    public List<Tree> Children { get; set; } = new();
    public bool IsLeaf => Children.Count == 0;
}

public static class TreeBuilder
{
    public static Tree BuildTree(IEnumerable<TreeBuildingRecord> records)
    {
        var sortedRecords = records.OrderBy(r => r.RecordId).ToList();

        if (sortedRecords.Count == 0)
        {
            throw new ArgumentException("Tree must have at least one record.");
        }

        // Validate the root node
        var rootRecord = sortedRecords[0];
        if (rootRecord.RecordId != 0 || rootRecord.ParentId != 0)
        {
            throw new ArgumentException("Invalid root node.");
        }

        // Initialize nodes list with the capacity of the record count
        var nodes = new Tree[sortedRecords.Count];
        nodes[0] = new Tree { Id = 0, ParentId = 0 };

        for (int i = 1; i < sortedRecords.Count; i++)
        {
            var record = sortedRecords[i];

            // Validate record consistency:
            // 1. IDs must be continuous (i == record.RecordId)
            // 2. Parent ID must be less than current ID (except for root)
            if (record.RecordId != i || record.ParentId >= record.RecordId)
            {
                throw new ArgumentException("Invalid record sequence or parent relationship.");
            }

            // Create the current node
            nodes[i] = new Tree { Id = record.RecordId, ParentId = record.ParentId };

            // Link to parent (O(1) lookup since we have the parent array)
            nodes[record.ParentId].Children.Add(nodes[i]);
        }

        return nodes[0];
    }
}